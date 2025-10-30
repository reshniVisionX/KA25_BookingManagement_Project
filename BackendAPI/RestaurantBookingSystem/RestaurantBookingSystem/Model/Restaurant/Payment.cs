using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Restaurant
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]

        [Required]
        [Range(0, 99999999.99)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public PayMethod PayMethod { get; set; } = PayMethod.UPI;// 'Cash', 'Card', 'UPI', 'Wallet'

        [Required]
       
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;// 'Pending', 'Completed', 'Failed'

        public Orders? Order { get; set; }
    }
}
public enum PayMethod
{
    Cash,
    Card,
    UPI,
    Wallet
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}