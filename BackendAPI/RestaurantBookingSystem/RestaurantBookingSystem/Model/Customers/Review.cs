using RestaurantBookingSystem.Model.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Customers
{
    public class Review
    {
        [Key]
         public int ReviewId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
     
        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]

        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; } = 10;

        public string? Comments { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        public Users? User { get; set; }

        public Restaurants? Restaurant { get; set; }

    }
}
