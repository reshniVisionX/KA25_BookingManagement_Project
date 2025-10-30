using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Manager
{
    public class ManagerDetails
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        [StringLength(50)]
        public string ManagerName { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public IsVerified? Verification { get; set; } = IsVerified.Unverified;

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        public ICollection<Restaurants>? Restaurants { get; set; }
    }
}

    public enum IsVerified
    {
        Unverified,
        Verified,
        Rejected
    }