using System.ComponentModel.DataAnnotations;

namespace OnlineRetail.Models
{
    public class CategoriesDto
    {
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}
