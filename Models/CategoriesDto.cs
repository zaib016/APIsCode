using System.ComponentModel.DataAnnotations;

namespace OnlineRetail.Models
{
    //Dto stand for Data tarnsfar object
    public class CategoriesDto
    {
        public required string CategoryName { get; set; }
        public required string Description { get; set; }
    }
}
