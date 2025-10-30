using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Model.Customers;
using RestaurantBookingSystem.Model.Delivery;
using RestaurantBookingSystem.Model.Manager;
using RestaurantBookingSystem.Model.Restaurant;
using System;

namespace RestaurantBookingSystem.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        public DbSet<Restaurants> Restaurants { get; set; }
        public DbSet<MenuList> MenuList { get; set; }
        public DbSet<DineIn> DineIn { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryPerson> DeliveryPerson { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddress { get; set; }

        public DbSet<ManagerDetails> ManagerDetails { get; set; }
        public DbSet<ManagerPayment> ManagerPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ===================== ENUM CONVERSIONS =====================
            modelBuilder.Entity<DeliveryPerson>().Property(d => d.Status).HasConversion<string>();
            modelBuilder.Entity<Delivery>().Property(d => d.DeliveryStatus).HasConversion<string>();
            modelBuilder.Entity<DineIn>().Property(t => t.Status).HasConversion<string>();
            modelBuilder.Entity<Orders>().Property(o => o.Status).HasConversion<string>();
            modelBuilder.Entity<Orders>().Property(o => o.OrderType).HasConversion<string>();
            modelBuilder.Entity<Payment>().Property(p => p.PayMethod).HasConversion<string>();
            modelBuilder.Entity<Payment>().Property(p => p.Status).HasConversion<string>();
            modelBuilder.Entity<Reservation>().Property(r => r.Status).HasConversion<string>();
            modelBuilder.Entity<UserPreferences>().Property(u => u.Theme).HasConversion<string>();
            modelBuilder.Entity<Restaurants>().Property(r => r.RestaurantType).HasConversion<string>();
            modelBuilder.Entity<Restaurants>().Property(r => r.RestaurantCategory).HasConversion<string>();
            modelBuilder.Entity<ManagerDetails>()
              .Property(m => m.Verification)
              .HasConversion<string>();
            


            // ===================== PRECISION SETTINGS =====================
            modelBuilder.Entity<MenuList>().Property(m => m.Price).HasPrecision(10, 2);
            modelBuilder.Entity<MenuList>().Property(m => m.Tax).HasPrecision(5, 2);
            modelBuilder.Entity<Orders>().Property(o => o.TotalAmount).HasPrecision(10, 2);
            modelBuilder.Entity<Payment>().Property(p => p.Amount).HasPrecision(10, 2);
            modelBuilder.Entity<Restaurants>().Property(r => r.DeliveryCharge).HasPrecision(8, 2);
            modelBuilder.Entity<Restaurants>().Property(r => r.Ratings).HasPrecision(3, 1);
            modelBuilder.Entity<Review>().Property(r => r.Rating).HasPrecision(3, 1);
            modelBuilder.Entity<ManagerPayment>().Property(m => m.Amount).HasPrecision(10, 2);

            // ===================== UNIQUE CONSTRAINTS =====================
            modelBuilder.Entity<Users>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Roles>().HasIndex(r => r.RoleName).IsUnique();
            modelBuilder.Entity<Restaurants>().HasIndex(r => r.RestaurantName).IsUnique();
            modelBuilder.Entity<DineIn>().HasIndex(t => new { t.RestaurantId, t.TableNo }).IsUnique();
            modelBuilder.Entity<DeliveryPerson>().HasIndex(d => d.MobileNo).IsUnique();
            modelBuilder.Entity<Wishlist>().HasIndex(w => new { w.UserId, w.ItemId, w.RestaurantId }).IsUnique();
            modelBuilder.Entity<ManagerDetails>().HasIndex(m => m.Email).IsUnique();

            // ===================== RELATIONSHIPS =====================
            modelBuilder.Entity<Restaurants>()
                 .HasOne(r => r.Manager)
                .WithMany(m => m.Restaurants)
               .HasForeignKey(r => r.ManagerId)
              .OnDelete(DeleteBehavior.Restrict);



            // ========== SEED DATA ==========
            var staticDate1 = new DateTime(2023, 1, 1, 12, 0, 0);
            var staticDate2 = new DateTime(2023, 1, 2, 12, 0, 0);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Customer", Description = "Standard customer account" },
                new Roles { RoleId = 3, RoleName = "Admin", Description = "Restaurant administrator" },
                 new Roles { RoleId = 2, RoleName = "Manager", Description = "Manages Restaurant" }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    Password = "hashedPassword1",
                    RoleId = 2,
                    IsActive = true,
                    CreatedAt = staticDate1,
                    LastLogin = staticDate1
                },
                new Users
                {
                    UserId = 2,
                    FirstName = "Admin",
                    LastName = "",
                    Email = "admin@example.com",
                    Password = "hashedPassword2",
                    RoleId = 1,
                    IsActive = true,
                    CreatedAt = staticDate1,
                    LastLogin = staticDate2
                }
            );
            modelBuilder.Entity<ManagerDetails>().HasData(
      new ManagerDetails
      {
          ManagerId = 1,
          ManagerName = "Arjun Kumar",
          UserId = 1,                    
          Email = "arjun@manager.com",
          PhoneNumber = "9876543210",
          PasswordHash = "hashed123",  
          IsActive = true,
          Verification=IsVerified.Unverified,
          CreatedAt = staticDate1,
          UpdatedAt = staticDate1
      });

          modelBuilder.Entity<Restaurants>().HasData(
                new Restaurants
                {
                    RestaurantId = 1,
                    RestaurantName = "Spice Garden",
                    Description = "Authentic Indian Cuisine",
                    Ratings = 9.2m,
                    RestaurantType = FoodType.Both,
                    RestaurantCategory = RestaurantCategory.Restaurant,
                    Location = "MG Road, Chennai",
                    City = "Chennai",
                    ContactNo = "9876543210",
                    DeliveryCharge = 50,
                    ManagerId = 1,
                    IsActive = true,
                    CreatedAt = staticDate1
                }
              
            );

            modelBuilder.Entity<DeliveryPerson>().HasData(
                new DeliveryPerson
                {
                    DeliveryPersonId = 1,
                    DeliveryName = "Arjun Kumar",
                    MobileNo = "9876543210",
                    Email = "arjun@delivery.com",
                    LicenseNumber = "TN45DL7890",
                  
                    Status = DeliveryPersonStatus.Available,
                    TotalDeliveries = 100,
                    AverageRating = 4.8
                }
              
            );

            // ==================== MENU LIST ====================
            modelBuilder.Entity<MenuList>().HasData(
                new MenuList
                {
                    ItemId = 1,
                    RestaurantId = 1,
                    ItemName = "Butter Chicken",
                    Description = "Classic Indian curry",
                    AvailableQty = 50,
                    Discount = 10,
                    Price = 250,
                    IsVegetarian = false,
                    Tax = 18,
                    Image = null
                },
                new MenuList
                {
                    ItemId = 2,
                    RestaurantId = 1,
                    ItemName = "Chocolate Cake",
                    Description = "Rich chocolate dessert",
                    AvailableQty = 30,
                    Discount = 5,
                    Price = 150,
                    IsVegetarian = true,
                    Tax = 5,
                    Image = null
                }
            );

            // ==================== DINE IN ====================
            modelBuilder.Entity<DineIn>().HasData(
                new DineIn
                {
                    TableId = 1,
                    RestaurantId = 1,
                    TableNo = "T1",
                    Capacity = 4,
                    Status = TableStatus.Available
                },
                new DineIn
                {
                    TableId = 2,
                    RestaurantId = 1,
                    TableNo = "T2",
                    Capacity = 6,
                    Status = TableStatus.Reserved
                }
            );

            var itemsList1 = new List<ItemQuantity> { new ItemQuantity { ItemId = 1,  Quantity = 2 } };
            var itemsList2 = new List<ItemQuantity> { new ItemQuantity { ItemId = 2,  Quantity = 1 } };

            modelBuilder.Entity<Orders>().HasData(
                new Orders
                {
                    OrderId = 1,
                    ItemsList = System.Text.Json.JsonSerializer.Serialize(itemsList1),
                    OrderType = OrderType.DineIn,
                    UserId = 1,
                    QtyOrdered = 2,
                    RestaurantId = 1,
                    OrderDate = staticDate1,
                    TotalAmount = 536, 
                    Status = OrderStatus.InProgress
                },
                new Orders
                {
                    OrderId = 2,
                    ItemsList = System.Text.Json.JsonSerializer.Serialize(itemsList2),
                    OrderType = OrderType.DineOut,
                    UserId = 1,
                    QtyOrdered = 1,
                    RestaurantId = 1,
                    OrderDate = staticDate2,
                    TotalAmount = 157,
                    Status = OrderStatus.Pending
                }
            );

            // ==================== PAYMENT ====================
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    PaymentId = 1,
                    OrderId = 1,
                    Amount = 536,
                    PaymentDate = staticDate1,
                    PayMethod = PayMethod.UPI,
                    Status = PaymentStatus.Completed
                },
                new Payment
                {
                    PaymentId = 2,
                    OrderId = 2,
                    Amount = 157,
                    PaymentDate = staticDate2,
                    PayMethod = PayMethod.Cash,
                    Status = PaymentStatus.Pending
                }
            );

           
            modelBuilder.Entity<DeliveryAddress>().HasData(
                new DeliveryAddress
                {
                    AddressId = 1,
                    UserId = 1,
                    Mobile = "9876543210",
                    Address = "123 MG Road",
                    City = "Chennai",
                    State = "Tamil Nadu",
                    Pincode = "600001",
                    Landmark = "Near Park",
                    ContactNo = "9876543210",
                    IsDefault = true
                },
                new DeliveryAddress
                {
                    AddressId = 2,
                    UserId = 1,
                    Mobile = "9876543220",
                    Address = "456 T Nagar",
                    City = "Chennai",
                    State = "Tamil Nadu",
                    Pincode = "600017",
                    Landmark = "Near Mall",
                    ContactNo = "9876543220",
                    IsDefault = false
                }
            );

            // ==================== CART ====================
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    CartId = 1,
                    UserId = 1,
                    ItemId = 1,
                    RestaurantId = 1,
                    Quantity = 2,
                    AddedAt = staticDate1
                },
                new Cart
                {
                    CartId = 2,
                    UserId = 1,
                    ItemId = 2,
                    RestaurantId = 1,
                    Quantity = 1,
                    AddedAt = staticDate2
                }
            );

            // ==================== REVIEW ====================
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    ReviewId = 1,
                    UserId = 1,
                    RestaurantId = 1,
                    Rating = 9,
                    Comments = "Excellent food and service!",
                    ReviewDate = staticDate1
                },
                new Review
                {
                    ReviewId = 2,
                    UserId = 1,
                    RestaurantId = 1,
                    Rating = 8,
                    Comments = "Loved the desserts",
                    ReviewDate = staticDate2
                }
            );

            // ==================== USER PREFERENCES ====================
            modelBuilder.Entity<UserPreferences>().HasData(
                new UserPreferences
                {
                    PreferenceId = 1,
                    UserId = 1,
                    Theme = UserTheme.Light,
                    NotificationsEnabled = true,
                    PreferredCity = "Chennai",
                    PreferredFoodType = "Indian"
                },
                new UserPreferences
                {
                    PreferenceId = 2,
                    UserId = 2,
                    Theme = UserTheme.Dark,
                    NotificationsEnabled = false,
                    PreferredCity = "Bangalore",
                    PreferredFoodType = "Desserts"
                }
            );

            // ==================== WISHLIST ====================
            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist
                {
                    WishlistId = 1,
                    UserId = 1,
                    ItemId = 1,
                    RestaurantId = 1,
                    CreatedAt = staticDate1
                },
                new Wishlist
                {
                    WishlistId = 2,
                    UserId = 1,
                    ItemId = 2,
                    RestaurantId = 2,
                    CreatedAt = staticDate2
                }
            );

        }
    }
}
