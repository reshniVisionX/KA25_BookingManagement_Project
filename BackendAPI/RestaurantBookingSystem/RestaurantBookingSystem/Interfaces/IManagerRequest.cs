using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Model.Manager;

namespace RestaurantBookingSystem.Interfaces
{
    public interface IManagerRequest
    {

        Task<bool> ProcessMonthlyPayoutToManagersAsync(PayoutDTO payout);
        Task<IEnumerable<PayoutDTO>> GetPayoutHistoryAsync(int managerId);

        Task<IEnumerable<ManagerDetails>> GetAllUnverifiedManagersAsync();

        Task<bool> VerifyManagerAsync(int managerId, bool isVerified);// if isverified is false, then reject

        Task<IEnumerable<ManagerDetails>> FilterManagersAsync(bool isActive, IsVerified? verification);



    }
}
