namespace RestaurantBookingSystem.DTOs
{
    public class AnalyticsDTO
    {
        public int NoOfRestaurants { get; set; }
        public int NoOfUsers { get; set; }
        public int NoOfManagers { get; set; }
        public int NoOfReservations { get; set; }
        public int NoOfActiveUsers { get; set; } 
        public int NoOfActiveReservations { get;set; }
        public int NoOfActiveManagers { get; set; } 
        public int DineInOrders { get; set; }
        public int DineOutOrders { get;set; }
        public int NoOfVegetarianHotels { get; set; }
        public int NoOfNonVegetarianHotels { get; set; }
        
    }
} 

