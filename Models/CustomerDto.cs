using System.ComponentModel.DataAnnotations;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Models
{
    public class CustomerDto
    {
        [Key]
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
