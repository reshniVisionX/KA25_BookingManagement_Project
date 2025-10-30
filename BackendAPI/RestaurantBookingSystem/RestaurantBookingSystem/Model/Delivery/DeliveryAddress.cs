using RestaurantBookingSystem.Model.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Delivery
{
    // One user can have multiple delivery addresses and 1 default address
    public class DeliveryAddress
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [Required]
        [StringLength(10)]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string State { get; set; }

        [Required]
        [StringLength(10)]
        public string Pincode { get; set; }

        [StringLength(100)]
        public string? Landmark { get; set; }

        [StringLength(20)]
        public string? ContactNo { get; set; }

        public bool IsDefault { get; set; } = false;
    }
}