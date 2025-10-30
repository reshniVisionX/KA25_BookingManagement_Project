using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Delivery
{
    public class DeliveryPerson
    {
        [Key]
        public int DeliveryPersonId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string DeliveryName { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string MobileNo { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; } = null;

        [Required]
        [StringLength(15)]
        public string LicenseNumber { get; set; }

        [StringLength(6)]
        public int? otp { get; set; }

        [Required]
        public DeliveryPersonStatus Status { get; set; } = DeliveryPersonStatus.Available;

        [Range(0, int.MaxValue)]
        public int TotalDeliveries { get; set; } = 0;

        [Range(0.0, 5.0)]
        public double AverageRating { get; set; } = 0.0;
    }

    public enum DeliveryPersonStatus
    {
        Available,
        OnDelivery,
        Inactive
    }
}
