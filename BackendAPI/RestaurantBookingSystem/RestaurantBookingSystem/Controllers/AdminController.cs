using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.DTOs;
using RestaurantBookingSystem.Model.Restaurant;
using RestaurantBookingSystem.Services;

namespace RestaurantBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices _adminService;

        public AdminController(AdminServices adminService)
        {
            _adminService = adminService;
        }

        // ------------------- Restaurants -------------------
        [HttpGet("restaurants")]
        public async Task<ActionResult> GetAllRestaurants()
        {
            var result = await _adminService.GetAllRestaurantsAsync();
            return Ok(result);
        }

        [HttpGet("restaurants/filter")]
        public async Task<ActionResult> FilterRestaurants(
            int? id, string? city, RestaurantCategory? category,
            FoodType? type, string? managerName)
        {
            var result = await _adminService.FilterRestaurants(id, city, category, type, managerName);
            return Ok(result);
        }

        [HttpPut("restaurants/{restaurantId}/toggle")]
        public async Task<ActionResult> ToggleRestaurantStatus(int restaurantId)
        {
            var success = await _adminService.ToggleRestaurantStatus(restaurantId);
            return success ? Ok("Status updated successfully.") : NotFound("Restaurant not found.");
        }

        // ------------------- Managers -------------------
        [HttpGet("managers")]
        public async Task<ActionResult> GetAllManagers(int roleId)
        {
            var result = await _adminService.GetAllManagersAsync(roleId);
            return Ok(result);
        }

        [HttpPut("managers/{managerId}/toggle")]
        public async Task<ActionResult> ToggleManagerStatus(int managerId)
        {
            var success = await _adminService.ToggleManagerStatus(managerId);
            return success ? Ok("Manager status updated.") : NotFound("Manager not found.");
        }

        // ------------------- Analytics -------------------
        [HttpGet("analytics/dashboard")]
        public async Task<ActionResult> GetDashboardAnalytics()
        {
            var result = await _adminService.GetDashboardAnalyticsAsync();
            return Ok(result);
        }

        [HttpGet("analytics/revenue")]
        public async Task<ActionResult> GetEntireRevenue([FromQuery] DateTime date)
        {
            var result = await _adminService.GetEntireRevenueAnalyticsAsync(date);
            return Ok(result);
        }

        [HttpGet("analytics/restaurant/{restaurantId}")]
        public async Task<ActionResult> GetRestaurantRevenue(int restaurantId)
        {
            var result = await _adminService.GetRestaurantRevenueAsync(restaurantId);
            return Ok(result);
        }
    }
}
