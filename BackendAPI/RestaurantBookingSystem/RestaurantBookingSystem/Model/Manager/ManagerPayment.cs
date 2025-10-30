using RestaurantBookingSystem.Model.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Manager
{
        public class ManagerPayment
        {
            [Key]
            public int ManagerPaymentId { get; set; }

            [Required]
            public int ManagerId { get; set; }

            [ForeignKey("ManagerId")]
            public ManagerDetails? Manager { get; set; }

            [Required]
            public int RestaurantId { get; set; }

            [ForeignKey("RestaurantId")]
            public Restaurants? Restaurant { get; set; }

            [Required]
            [Column(TypeName = "decimal(10,2)")]
            public decimal Amount { get; set; }

            public DateTime PaymentDate { get; set; } = DateTime.Now;

            public string PaymentStatus { get; set; } = "Paid";

            public string? Remarks { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
