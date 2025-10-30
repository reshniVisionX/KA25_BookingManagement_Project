using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json; // For JSON serialization

namespace RestaurantBookingSystem.Model.Restaurant
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; }
        public Restaurants? Restaurant { get; set; }
        [Required]
        public string ItemsList { get; set; } = string.Empty;

        [NotMapped] // EF ignores this property for database mapping
        // It hides the complexity of JSON. Developers just work with Items like a normal list.
        public List<ItemQuantity>? Items
        {
            get => string.IsNullOrEmpty(ItemsList)
                ? new List<ItemQuantity>()
                : JsonSerializer.Deserialize<List<ItemQuantity>>(ItemsList);
            set => ItemsList = JsonSerializer.Serialize(value);
        }
        [Required]
        public  OrderType OrderType { get; set; } = OrderType.DineIn;
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int QtyOrdered { get; set; } // Total quantity across all items

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [Range(0, 99999999.99)]
        public decimal TotalAmount { get; set; }

        [Required]
        public OrderStatus? Status { get; set; } = OrderStatus.InProgress;

    }

    // Helper class for item and quantity pair
    public class ItemQuantity
    {
        [Required]
        public int ItemId { get; set; }
      
        [Range(1, 100)]
        public int Quantity { get; set; }

    }

    public enum OrderStatus
    {
        Pending,
        InProgress,
        Completed,
        Cancelled
    }

    public enum OrderType
    {
        DineIn,
        DineOut
    }
}

// When saving to DB
//Items = new List<ItemQuantity>
//{
//    new ItemQuantity { ItemId = 1, RestaurantId = 5, Quantity = 2 },
//    new ItemQuantity { ItemId = 4, RestaurantId = 5, Quantity = 1 }
//};
