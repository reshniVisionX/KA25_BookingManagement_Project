namespace RestaurantBookingSystem.DTOs
{
    public class PayoutDTO
    {
        public int ManagerId { get; set; }
        public int RestaurantId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = "Monthly payout processed.";
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string PaymentStatus { get; set; } = "Paid";
    }
}
