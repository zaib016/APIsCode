using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OnlineRetail.Models.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required DateTime CreatedAt { get; set; }

        // Navigation property (One customer → many orders)
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
