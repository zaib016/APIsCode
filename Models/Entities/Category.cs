using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace OnlineRetail.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}
