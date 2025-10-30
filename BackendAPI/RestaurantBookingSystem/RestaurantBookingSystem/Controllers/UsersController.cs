using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Services;
using System.Text;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _service;
        private readonly SymmetricSecurityKey _key;
        private readonly TokenService _tokenService;
      

        public UsersController(UserServices service, IConfiguration configuration, TokenService tokenService)
        {
            _service = service;
            _key = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(configuration["TokenKey"]!)
           );
            _tokenService = tokenService;
           
        }
    

        // -------------------- REGISTER USER --------------------
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO dto)
        {
            try
            {
                var message = await _service.RegisterUserAsync(dto);
                return Ok(new
                {
                    success = true,
                    message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

        // -------------------- LOGIN USER --------------------
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var user = await _service.LoginAsync(dto);
              
                var token = _tokenService.GenerateToken(user);
                return Ok(new
                {
                    success = true,
                    message = "Login successful",
                    data = new
                    {
                        user.UserId,
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.Mobile,
                        user.RoleId,
                        user.LastLogin,
                        Token = token
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _service.GetAllUsersAsync();
            return Ok(users);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok(user);
        }
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("user-active/{userId}")]
        public async Task<ActionResult> ToggleActiveStatus(int userId)
        {
            try
            {
                await _service.ToggleUserActiveStatusAsync(userId);
                return Ok(new
                {
                    success = true,
                    message = "User active status toggled successfully"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    error = ex.Message
                });
            }
        }

    }
}
