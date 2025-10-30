namespace RestaurantBookingSystem.DTOs
{
    public class EntireRevenueDTO
    {
        public decimal DailyRevenue { get; set; }
        public decimal WeeklyRevenue { get; set; }

        public decimal MonthlyRevenue { get; set; }
        public decimal NoOfDailyOrders { get; set; }
        public decimal WeeklyOrders { get; set; }
        public decimal MonthlyOrders { get; set; }
    }
}
