using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Model.Manager;
using RestaurantBookingSystem.Services;

namespace RestaurantBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminManagerController : ControllerBase
    {
        private readonly AdminManagerService _service;

        public AdminManagerController(AdminManagerService service)
        {
            _service = service;
        }

        // ------------------- PAYOUTS -------------------
        [HttpPost("payout")]
        public async Task<IActionResult> ProcessPayout([FromBody] PayoutDTO payout)
        {
            try
            {
                var success = await _service.ProcessMonthlyPayoutToManagersAsync(payout);
                return success ? Ok("Payout processed successfully.") : BadRequest("Failed to process payout.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("payout-history/{managerId}")]
        public async Task<IActionResult> GetPayoutHistory(int managerId)
        {
            try
            {
                var result = await _service.GetPayoutHistoryAsync(managerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ------------------- MANAGER VERIFICATION -------------------
        [HttpGet("unverified")]
        public async Task<IActionResult> GetUnverifiedManagers()
        {
            var result = await _service.GetAllUnverifiedManagersAsync();
            return Ok(result);
        }

        [HttpPut("verify/{managerId}")]
        public async Task<IActionResult> VerifyManager(int managerId, [FromQuery] bool isVerified)
        {
            try
            {
                var success = await _service.VerifyManagerAsync(managerId, isVerified);
                return success
                    ? Ok(isVerified ? "Manager approved." : "Manager rejected.")
                    : NotFound("Manager not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterManagers(
            [FromQuery] bool isActive,
            [FromQuery] IsVerified? verification)
        {
            var result = await _service.FilterManagersAsync(isActive, verification);
            return Ok(result);
        }
    }
}
