using RestaurantBookingSystem.Model.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Restaurant
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [Required]
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public DineIn? Table { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public TimeSpan ReservationInTime { get; set; }

        [Required]
        public TimeSpan ReservationOutTime { get; set; }
         
        [Required]
        
        public ReservationStatus Status { get; set; } = ReservationStatus.Reserved; 
         
        public DateTime ReseveredAt { get; set; } = DateTime.UtcNow;

        public bool AdvancePayment { get; set; } =  false;
    }

    public enum ReservationStatus
    {
        Available,
        Reserved,
        Cancelled
    }
   
}