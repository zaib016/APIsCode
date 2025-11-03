using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineRetail.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public required string Price { get; set; }
    }
}
