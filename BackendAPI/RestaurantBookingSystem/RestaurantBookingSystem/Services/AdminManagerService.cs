using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Manager;

namespace RestaurantBookingSystem.Services
{
    public class AdminManagerService
    {
        private readonly IManagerRequest _managerRepo;

        public AdminManagerService(IManagerRequest managerRepo)
        {
            _managerRepo = managerRepo;
        }

        // ------------------- PAYOUTS -------------------
        public async Task<bool> ProcessMonthlyPayoutToManagersAsync(PayoutDTO payout)
        {
            // Validation rules
            if (payout == null)
                throw new ArgumentNullException(nameof(payout), "Payout details are required.");

            if (payout.ManagerId <= 0)
                throw new ArgumentException("Invalid Manager ID.");

            if (payout.RestaurantId <= 0)
                throw new ArgumentException("Invalid Restaurant ID.");

            if (payout.Amount <= 0)
                throw new ArgumentException("Payout amount must be greater than zero.");

            // Proceed with repo call
            return await _managerRepo.ProcessMonthlyPayoutToManagersAsync(payout);
        }

        public async Task<IEnumerable<PayoutDTO>> GetPayoutHistoryAsync(int managerId)
        {
            if (managerId <= 0)
                throw new ArgumentException("Invalid Manager ID.");

            return await _managerRepo.GetPayoutHistoryAsync(managerId);
        }

        // ------------------- MANAGER VERIFICATION -------------------
        public async Task<IEnumerable<ManagerDetails>> GetAllUnverifiedManagersAsync()
        {
            return await _managerRepo.GetAllUnverifiedManagersAsync();
        }

        public async Task<bool> VerifyManagerAsync(int managerId, bool isVerified)
        {
            if (managerId <= 0)
                throw new ArgumentException("Invalid Manager ID.");

            return await _managerRepo.VerifyManagerAsync(managerId, isVerified);
        }

        public async Task<IEnumerable<ManagerDetails>> FilterManagersAsync(bool isActive, IsVerified? verification)
        {
            return await _managerRepo.FilterManagersAsync(isActive, verification);
        }
    }
}
