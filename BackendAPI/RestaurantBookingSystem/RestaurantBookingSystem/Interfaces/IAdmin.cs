using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Manager;
using RestaurantBookingSystem.Model.Restaurant;
using RestaurantBookingSystem.DTOs;

namespace RestaurantBookingSystem.Interfaces
{
    public interface IAdmin
    {
        // ------------------- Restaurants -------------------
        Task<IEnumerable<Restaurants>> GetAllRestaurantsAsync();
        Task<IEnumerable<Restaurants>> FilterRestaurants(
            int? id,
            string? city,
            RestaurantCategory? category,
            FoodType? type,
            string? managerName);

        Task<Restaurants?> GetRestaurantByManagerIdAsync(int managerId);
        Task<bool> ToggleRestaurantStatus(int restaurantId);

        // ------------------- Managers -------------------
        Task<IEnumerable<Users>> GetAllManagersAsync(int roleId);
        Task<bool> ToggleManagerStatus(int managerId);

        // ------------------- Analytics -------------------
        Task<AnalyticsDTO> GetDashboardAnalyticsAsync();
        Task<IEnumerable<EntireRevenueDTO>> GetEntireRevenueAnalyticsAsync(DateTime date);
        Task<IEnumerable<RestaurantRevenueDTO>> GetRestaurantRevenueAsync(int restaurantId);

    }
}
