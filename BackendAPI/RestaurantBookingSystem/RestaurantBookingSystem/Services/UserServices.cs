using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Interfaces;
using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Repository;
using RestaurantBookingSystem.Utils;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;


namespace RestaurantBookingSystem.Services
{
    public class UserServices
    {
        private readonly IUsers _repo;
        public UserServices(IUsers userRepository)
        {
            _repo = userRepository;
        }

   
public async Task<string> RegisterUserAsync(RegisterDTO dto)
    {
        if (string.IsNullOrEmpty(dto.Email) && string.IsNullOrEmpty(dto.Mobile))
            throw new Exception("Either Email or Mobile number must be provided.");

        if (!string.IsNullOrEmpty(dto.Email))
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(dto.Email))
                throw new Exception("Invalid email format.");

            var existingEmailUser = await _repo.GetUserByEmailAsync(dto.Email);
            if (existingEmailUser != null)
                throw new Exception("Email already registered.");
        }

        if (!string.IsNullOrEmpty(dto.Mobile))
        {
            var mobileRegex = new Regex(@"^[6-9]\d{9}$");
            if (!mobileRegex.IsMatch(dto.Mobile))
                throw new Exception("Invalid mobile number. Must be 10 digits and start with 6–9.");

            var existingMobileUser = await _repo.GetUserByMobileAsync(dto.Mobile);
            if (existingMobileUser != null)
                throw new Exception("Mobile number already registered.");
        }

        if (string.IsNullOrEmpty(dto.Password) || dto.Password.Length < 6)
            throw new Exception("Password must be at least 6 characters long.");

        var PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var user = new Users
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = PasswordHash,
            Mobile = dto.Mobile,
            CreatedAt = DateTime.Now,
            IsActive = true
        };

        await _repo.AddUserAsync(user);
        await _repo.SaveChangesAsync();

        return "User registered successfully";
    }

    public async Task<Users> LoginAsync(LoginDTO dto)
        {
            if (!string.IsNullOrEmpty(dto.Email))
            {
                // EMAIL + PASSWORD LOGIN
                var user = await _repo.GetUserByEmailAsync(dto.Email);
                if (user == null || user.Password == null)
                    throw new Exception("Enter all credentials.");
                if (!user.IsActive)
                    throw new Exception("EmailId isn't active contact Admin");


                if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                    throw new Exception("Invalid password.");

                user.LastLogin = DateTime.Now;
                await _repo.SaveChangesAsync();
                return user;
            }
            else if (!string.IsNullOrEmpty(dto.Mobile))
            {
                // MOBILE + OTP LOGIN
                var user = await _repo.GetUserByMobileAsync(dto.Mobile);
                if (user == null)
                    throw new Exception("Mobile number not registered.");
                if (!user.IsActive)
                    throw new Exception("User isn't active contact Admin.");


                if (string.IsNullOrEmpty(dto.Otp))
                {
                    // Generate OTP and send (simulated here)
                    var otp = OTPGenerator.GenerateTOTP(dto.Mobile);
                    Console.WriteLine($"[DEBUG] OTP for {dto.Mobile}: {otp}");
                    throw new Exception("OTP sent to your mobile. Please enter it within 2 minutes.");
                }

                bool isValid = OTPGenerator.VerifyTOTP(dto.Mobile, dto.Otp);
                if (!isValid)
                    throw new Exception("Invalid or expired OTP.");

                user.LastLogin = DateTime.Now;
                await _repo.SaveChangesAsync();
                return user;
            }
            else
            {
                throw new Exception("Please provide either Email or Mobile number to login.");
            }
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _repo.GetAllUsersAsync();
        }

        public async Task<Users?> GetUserByIdAsync(int id)
        {
            return await _repo.GetUserByIdAsync(id);
        }
        public async Task ToggleUserActiveStatusAsync(int userId)
        {
            var user = await _repo.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            await _repo.ToggleUserActiveStatusAsync(user); 
        }


    }
}
