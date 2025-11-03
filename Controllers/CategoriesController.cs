using Microsoft.AspNetCore.Mvc;
using OnlineRetail.Data;
using OnlineRetail.Models;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ApplicationDbContext DbContext;

        public CategoriesController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(DbContext.Categories.ToList());
        }
        [HttpPost]
        public IActionResult AddCategories(CategoriesDto categoriesDto)
        {
            var category = new Category()
            {
                CategoryName = categoriesDto.CategoryName,
                Description = categoriesDto.Description,
            };
            DbContext.Categories.Add(category);
            DbContext.SaveChanges();
            return Ok(category);
           
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCategoriesByID(int id)
        {
            var category = DbContext.Categories.Find(id);
            if(category is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategories(int id, CategoriesDto categoriesDto)
        {
            var categories = DbContext.Categories.Find(id);

            if(categories is null)
            {
                return NotFound();
            }

            categories.CategoryName = categoriesDto.CategoryName;
            categories.Description = categoriesDto.Description;

            DbContext.SaveChanges();
            return Ok(categories);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategories(int id)
        {
            var categories = DbContext.Categories.Find(id);

            if(categories is null)
            {
                return NotFound();
            }
            DbContext.Categories.Remove(categories);
            DbContext.SaveChanges();

            return Ok("Delete Categories Successfully");
        }
        
    }
}
