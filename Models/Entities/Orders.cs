using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineRetail.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        // Foreign key property
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        // Navigation property
        //public virtual Customer Customer { get; set; }

        public required DateTime OrderDate { get; set; }
        public required string TotalAmount { get; set; }
    }


}
