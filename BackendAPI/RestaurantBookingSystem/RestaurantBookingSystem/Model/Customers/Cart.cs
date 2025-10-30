using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Customers
{
    // hold the item added to the cart from diff restaurant to order at once.
    // cartId must be cleared once it is ordered and pushed to the orders table
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ItemId { get; set; }

        [Required]
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]

        [Required]
        [Range(1, 50)]
        public int Quantity { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [ForeignKey("ItemId")]
        public DateTime AddedAt { get; set; } = DateTime.Now;
    }

}
