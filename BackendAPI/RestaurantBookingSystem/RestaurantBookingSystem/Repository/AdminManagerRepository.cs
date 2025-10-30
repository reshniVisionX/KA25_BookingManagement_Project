using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Data;
using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Manager;

namespace RestaurantBookingSystem.Repository
{
    public class AdminManagerRepository : IManagerRequest
    {
        private readonly BookingContext _context;

        public AdminManagerRepository(BookingContext context)
        {
            _context = context;
        }

        // ------------------- PAYOUTS -------------------
        public async Task<bool> ProcessMonthlyPayoutToManagersAsync(PayoutDTO payout)
        {
            var payment = new ManagerPayment
            {
                ManagerId = payout.ManagerId,
                RestaurantId = payout.RestaurantId,
                Amount = payout.Amount,
                Remarks = payout.Remarks,
                PaymentStatus = payout.PaymentStatus,
                PaymentDate = payout.PaymentDate,
                CreatedAt = DateTime.Now
            };

            await _context.ManagerPayments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PayoutDTO>> GetPayoutHistoryAsync(int managerId)
        {
            return await _context.ManagerPayments
                .Where(p => p.ManagerId == managerId)
                .Select(p => new PayoutDTO
                {
                    ManagerId = p.ManagerId,
                    RestaurantId = p.RestaurantId,
                    Amount = p.Amount,
                    Remarks = p.Remarks,
                    PaymentStatus = p.PaymentStatus,
                    PaymentDate = p.PaymentDate
                })
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }

        // ------------------- MANAGER VERIFICATION -------------------
        public async Task<IEnumerable<ManagerDetails>> GetAllUnverifiedManagersAsync()
        {
            return await _context.ManagerDetails
                .Where(m => m.Verification == IsVerified.Unverified)
                .ToListAsync();
        }

        public async Task<bool> VerifyManagerAsync(int managerId, bool isVerified)
        {
            var manager = await _context.ManagerDetails.FindAsync(managerId);
            if (manager == null)
                return false;

            manager.Verification = isVerified ? IsVerified.Verified : IsVerified.Rejected;
            manager.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ManagerDetails>> FilterManagersAsync(bool isActive, IsVerified? verification)
        {
            var query = _context.ManagerDetails.AsQueryable();

            query = query.Where(m => m.IsActive == isActive);

            if (verification.HasValue)
                query = query.Where(m => m.Verification == verification.Value);

            return await query.ToListAsync();
        }
    }
}
