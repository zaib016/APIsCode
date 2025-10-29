using System.ComponentModel.DataAnnotations;

namespace OnlineRetail.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public required string Price { get; set; }
        public int? Stock { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
