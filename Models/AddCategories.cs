using System.ComponentModel.DataAnnotations;

namespace OnlineRetail.Models
{
    public class AddCategories
    {
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}
