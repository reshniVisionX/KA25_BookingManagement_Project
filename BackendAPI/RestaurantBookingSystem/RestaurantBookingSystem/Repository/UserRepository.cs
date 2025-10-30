
using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Data;
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Customers;
using System;

namespace RestaurantBookingSystem.Repository
{
    public class UserRepository : IUsers
    {
        private readonly BookingContext _context;
        public UserRepository(BookingContext context)
        {
            _context = context;
        }
        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Users?> GetUserByMobileAsync(string mobile)
        {
            return await _context.Users
                .Include(u => u.Role) 
                .FirstOrDefaultAsync(u => u.Mobile == mobile);
        }

        public async Task AddUserAsync(Users user)
        {
            await _context.Users.AddAsync(user);
          
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Users?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task ToggleUserActiveStatusAsync(Users user)
        {
            user.IsActive = !user.IsActive; // toggle
            _context.Users.Update(user);    // mark entity as modified
            await _context.SaveChangesAsync();
        }
    }
}
