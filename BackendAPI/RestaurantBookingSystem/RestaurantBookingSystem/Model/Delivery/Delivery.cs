using RestaurantBookingSystem.Model.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Delivery
{
    public class Delivery
    {
        [Key]
        public int DeliveryId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Orders? Order { get; set; }

        [Required]
        public int DeliveryPersonId { get; set; }

        [ForeignKey(nameof(DeliveryPersonId))]
        public DeliveryPerson? DeliveryPerson { get; set; }

        [Required]
        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Pending;
        public DateTime? EstimatedDeliveryTime { get; set; }
        public DateTime? DeliveredAt { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public DeliveryAddress? Address { get; set; }
    }

    public enum DeliveryStatus
    {
        Pending,
        OutForDelivery,
        Delivered,
        Failed
    }
}
