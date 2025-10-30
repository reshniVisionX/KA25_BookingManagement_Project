using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Customers
{
    // this holds the liked dish for the user
    public class Wishlist
    {
        [Key]
        public int WishlistId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
     
        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]

        public Users? User { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
