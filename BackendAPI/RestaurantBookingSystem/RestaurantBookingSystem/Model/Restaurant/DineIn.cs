using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Restaurant
{
    public class DineIn
    {
        [Key]
        public int TableId { get; set; }
        [ForeignKey("RestaurantId")]
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        [StringLength(50)]
      
        public string TableNo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Capacity { get; set; } = 4;

        [Required]
    
        public TableStatus Status { get; set; } = TableStatus.Available;

        public Restaurants? Restaurants { get; set; }


    }
}

public enum TableStatus
{
    Available,
    Occupied,
    Reserved
}

