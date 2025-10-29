using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineRetail.Models
{
    public class UpdateOrderDto
    {
        // Foreign key property
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        // Navigation property
        //public virtual Customer Customer { get; set; }

        public required DateTime OrderDate { get; set; }
        public required string TotalAmount { get; set; }
    }
}
