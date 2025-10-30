using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Customers
{
    public class UserPreferences
    {
        [Key]
         public int PreferenceId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]

        [Required]
        [StringLength(20)]
        public UserTheme? Theme { get; set; } = UserTheme.Light;// 'Dark', 'Light'

        public bool? NotificationsEnabled { get; set; } = true;

        [StringLength(100)]
        public string? PreferredCity { get; set; } 

        [StringLength(100)]
        public string? PreferredFoodType { get; set; }

        public Users? User { get; set; }

    }
}
public enum UserTheme
{
  Dark,
  Light,
  SystemDefault
}