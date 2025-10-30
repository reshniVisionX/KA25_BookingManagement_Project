using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Data;            
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Manager;
using RestaurantBookingSystem.Model.Restaurant;

namespace RestaurantBookingSystem.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly BookingContext _context;

        public AdminRepository(BookingContext context)
        {
            _context = context;
        }

        // ------------------- Restaurants -------------------
        public async Task<IEnumerable<Restaurants>> GetAllRestaurantsAsync()
        {
            return await _context.Restaurants
                         .Include(r => r.Manager)                 // ManagerDetails
                         .ToListAsync();
        }

        public async Task<IEnumerable<Restaurants>> FilterRestaurants(
            int? id,
            string? city,
            RestaurantCategory? category,
            FoodType? type,
            string? managerName)
        {
            var query = _context.Restaurants
                        .Include(r => r.Manager)
                        .AsQueryable();

            if (id.HasValue)
                query = query.Where(r => r.RestaurantId == id.Value);

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(r => EF.Functions.Like(r.City, $"%{city}%"));

            if (category.HasValue)
                query = query.Where(r => r.RestaurantCategory == category.Value);

            if (type.HasValue)
                query = query.Where(r => r.RestaurantType == type.Value);

            if (!string.IsNullOrWhiteSpace(managerName))
                query = query.Where(r => r.Manager != null &&
                                         EF.Functions.Like(r.Manager.ManagerName, $"%{managerName}%"));

            return await query.ToListAsync();
        }

        public async Task<Restaurants?> GetRestaurantByManagerIdAsync(int managerId)
        {
            return await _context.Restaurants
                         .Include(r => r.Manager)
                         .FirstOrDefaultAsync(r => r.ManagerId == managerId);
        }

        public async Task<bool> ToggleRestaurantStatus(int restaurantId)
        {
            var restaurant = await _context.Restaurants.FindAsync(restaurantId);
            if (restaurant == null) return false;

            restaurant.IsActive = !restaurant.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        // ------------------- Managers -------------------
        // NOTE: managers are stored in ManagerDetails (not Users).
        public async Task<IEnumerable<Users>> GetAllManagersAsync(int roleId)
        {
            // If you truly want the Users who are managers (joined by RoleId),
            // return Users filtered by RoleId. Otherwise, you can return ManagerDetails.
            // Here I return Users where RoleId == roleId (keeps the original signature).
            return await _context.Users
                        .Where(u => u.RoleId == roleId)
                        .ToListAsync();
        }

        public async Task<bool> ToggleManagerStatus(int managerId)
        {
            // Toggle the ManagerDetails.IsActive flag (managerId is ManagerDetails.ManagerId)
            var manager = await _context.ManagerDetails.FindAsync(managerId);
            if (manager == null) return false;

            manager.IsActive = !manager.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

        // ------------------- Analytics -------------------
        public async Task<AnalyticsDTO> GetDashboardAnalyticsAsync()
        {
            // Use DB-side counts (mapped to your model fields)
            var dto = new AnalyticsDTO
            {
                NoOfRestaurants = await _context.Restaurants.CountAsync(),
                NoOfUsers = await _context.Users.CountAsync(),
                // Count managers from ManagerDetails (preferred) — earlier code used Users.Role == "Manager"
                NoOfManagers = await _context.ManagerDetails.CountAsync(),
                NoOfReservations = await _context.Reservation.CountAsync(),
                NoOfActiveUsers = await _context.Users.CountAsync(u => u.IsActive),
                NoOfActiveManagers = await _context.ManagerDetails.CountAsync(m => m.IsActive),
                NoOfActiveReservations = await _context.Reservation.CountAsync(r => r.Status == ReservationStatus.Reserved),
                DineInOrders = await _context.Orders.CountAsync(o => o.OrderType == OrderType.DineIn),
                DineOutOrders = await _context.Orders.CountAsync(o => o.OrderType == OrderType.DineOut),
                NoOfVegetarianHotels = await _context.Restaurants.CountAsync(r => r.RestaurantType == FoodType.Veg),
                NoOfNonVegetarianHotels = await _context.Restaurants.CountAsync(r => r.RestaurantType == FoodType.Nonveg)
            };

            return dto;
        }

        public async Task<IEnumerable<EntireRevenueDTO>> GetEntireRevenueAnalyticsAsync(DateTime date)
        {
            var today = date.Date;
            var weekAgo = today.AddDays(-7);
            var monthAgo = today.AddMonths(-1);

            // Do the aggregation in the DB, not by loading all orders into memory
            var agg = await _context.Orders
                .GroupBy(o => 1)   // single group for whole dataset
                .Select(g => new EntireRevenueDTO
                {
                    DailyRevenue = g.Where(o => o.OrderDate.Date == today).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    WeeklyRevenue = g.Where(o => o.OrderDate.Date >= weekAgo).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    MonthlyRevenue = g.Where(o => o.OrderDate.Date >= monthAgo).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    NoOfDailyOrders = g.Count(o => o.OrderDate.Date == today),
                    WeeklyOrders = g.Count(o => o.OrderDate.Date >= weekAgo),
                    MonthlyOrders = g.Count(o => o.OrderDate.Date >= monthAgo)
                })
                .ToListAsync();

            // If no orders exist the grouping returns empty — ensure we return a zero DTO
            if (!agg.Any())
            {
                return new List<EntireRevenueDTO> {
                    new EntireRevenueDTO {
                        DailyRevenue = 0,
                        WeeklyRevenue = 0,
                        MonthlyRevenue = 0,
                        NoOfDailyOrders = 0,
                        WeeklyOrders = 0,
                        MonthlyOrders = 0
                    }
                };
            }

            return agg;
        }

        public async Task<IEnumerable<RestaurantRevenueDTO>> GetRestaurantRevenueAsync(int restaurantId)
        {
            var today = DateTime.Today;
            var weekAgo = today.AddDays(-7);
            var monthAgo = today.AddMonths(-1);

            var data = await _context.Orders
                .Where(o => o.RestaurantId == restaurantId)
                .GroupBy(o => o.RestaurantId)
                .Select(g => new RestaurantRevenueDTO
                {
                    RestaurantId = g.Key,
                    RestaurantName = _context.Restaurants
                                       .Where(r => r.RestaurantId == g.Key)
                                       .Select(r => r.RestaurantName)
                                       .FirstOrDefault(),
                    DailyRevenue = g.Where(o => o.OrderDate.Date == today).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    WeeklyRevenue = g.Where(o => o.OrderDate.Date >= weekAgo).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    MonthlyRevenue = g.Where(o => o.OrderDate.Date >= monthAgo).Sum(o => (decimal?)o.TotalAmount) ?? 0M,
                    NoOfDailyOrders = g.Count(o => o.OrderDate.Date == today),
                    WeeklyOrders = g.Count(o => o.OrderDate.Date >= weekAgo),
                    MonthlyOrders = g.Count(o => o.OrderDate.Date >= monthAgo)
                })
                .ToListAsync();

            // If there are zero orders, return a DTO with zeroes and the restaurant name (or empty)
            if (!data.Any())
            {
                var name = await _context.Restaurants
                                .Where(r => r.RestaurantId == restaurantId)
                                .Select(r => r.RestaurantName)
                                .FirstOrDefaultAsync();

                return new List<RestaurantRevenueDTO> {
                    new RestaurantRevenueDTO {
                        RestaurantId = restaurantId,
                        RestaurantName = name ?? string.Empty,
                        DailyRevenue = 0,
                        WeeklyRevenue = 0,
                        MonthlyRevenue = 0,
                        NoOfDailyOrders = 0,
                        WeeklyOrders = 0,
                        MonthlyOrders = 0
                    }
                };
            }

            return data;
        }
    }
}
