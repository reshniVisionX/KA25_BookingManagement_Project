using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RestaurantBookingSystem.Model.Customers
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [StringLength(100)]
        public string? FirstName { get; set; }

        [StringLength(100)]
        public string? LastName { get; set; }



        [StringLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(100)]
        
        public string? Password { get; set; }

    
        [Phone]
        public string? Mobile { get; set; }

        [Required]
        public int RoleId { get; set; } = 1;

        [ForeignKey("RoleId")]
         

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? LastLogin { get; set; } = DateTime.Now;
        public Roles? Role { get; set; }
    }
}
