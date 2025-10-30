using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantBookingSystem.Model.Customers
{
    public class Roles
    {
        [Key]
       
        public int RoleId { get; set; }

        [Required]
        [StringLength(100)]

        public string RoleName { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
