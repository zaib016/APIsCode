namespace OnlineRetail.Models
{
    public class AddOrderItemDto
    {
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public required string Price { get; set; }
    }
}
