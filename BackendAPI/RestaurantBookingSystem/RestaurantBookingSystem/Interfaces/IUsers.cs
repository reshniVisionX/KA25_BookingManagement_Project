using RestaurantBookingSystem.Model.Customers;

namespace RestaurantBookingSystem.Interfaces
{
    public interface IUsers
    {
        Task<Users?> GetUserByEmailAsync(string email);
        Task<Users?> GetUserByMobileAsync(string mobile);
        Task AddUserAsync(Users user);
        Task SaveChangesAsync();
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users?> GetUserByIdAsync(int id);
        Task ToggleUserActiveStatusAsync(Users user);
    }
}
