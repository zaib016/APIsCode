using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetail.Data;
using OnlineRetail.Models;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(dbContext.Products.ToList());
        }
        [HttpPost]
        public IActionResult AddProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                ProductName = productDto.ProductName,
                CategoryID = productDto.CategoryID,
                Price = productDto.Price,
                Stock = productDto.Stock,
                CreatedAt = productDto.CreatedAt,
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return Ok(product);

        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProductByID(int id)
        {
            var product = dbContext.Products.Find(id);

            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateProduct(int id, ProductDto productDto)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            product.ProductName = productDto.ProductName;
            product.CategoryID = productDto.CategoryID;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.CreatedAt = productDto.CreatedAt;

            dbContext.SaveChanges();

            return Ok(product);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct(int id) 
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();

            return Ok(product);

        }
    }
}
