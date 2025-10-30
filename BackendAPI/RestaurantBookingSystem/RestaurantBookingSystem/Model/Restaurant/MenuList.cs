using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Restaurant
{
    public class MenuList
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableQty { get; set; }

        [Column(TypeName = "decimal(10,2)")]    
        public decimal Discount { get; set; } = 0;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool IsVegetarian { get; set; } = false;
        [Range(0, 99999999.99)]
        public decimal Tax { get; set; }

        public byte[]? Image { get; set; } // VARBINARY(MAX) for binary image data

        [ForeignKey("RestaurantId")]
        public Restaurants? Restaurant { get; set; }
    }
}
