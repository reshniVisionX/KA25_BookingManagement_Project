using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Restaurant;

namespace RestaurantBookingSystem.Services
{
    public class AdminServices
    {
        private readonly IAdmin _adminRepo;

        public AdminServices(IAdmin adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public Task<IEnumerable<Restaurants>> GetAllRestaurantsAsync() =>
            _adminRepo.GetAllRestaurantsAsync();

        public Task<IEnumerable<Restaurants>> FilterRestaurants(
            int? id, string? city, RestaurantCategory? category,
            FoodType? type, string? managerName) =>
            _adminRepo.FilterRestaurants(id, city, category, type, managerName);

        public Task<Restaurants?> GetRestaurantByManagerIdAsync(int managerId) =>
            _adminRepo.GetRestaurantByManagerIdAsync(managerId);

        public Task<bool> ToggleRestaurantStatus(int restaurantId) =>
            _adminRepo.ToggleRestaurantStatus(restaurantId);

        public Task<IEnumerable<Users>> GetAllManagersAsync(int roleId) =>
            _adminRepo.GetAllManagersAsync(roleId);

        public Task<bool> ToggleManagerStatus(int managerId) =>
            _adminRepo.ToggleManagerStatus(managerId);

        public Task<AnalyticsDTO> GetDashboardAnalyticsAsync() =>
            _adminRepo.GetDashboardAnalyticsAsync();

        public Task<IEnumerable<EntireRevenueDTO>> GetEntireRevenueAnalyticsAsync(DateTime date) =>
            _adminRepo.GetEntireRevenueAnalyticsAsync(date);

        public Task<IEnumerable<RestaurantRevenueDTO>> GetRestaurantRevenueAsync(int restaurantId) =>
            _adminRepo.GetRestaurantRevenueAsync(restaurantId);
    }
}
