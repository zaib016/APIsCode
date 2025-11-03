namespace OnlineRetail.Models
{
    public class ProductDto
    {
        public required string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public required string Price { get; set; }
        public int? Stock { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
