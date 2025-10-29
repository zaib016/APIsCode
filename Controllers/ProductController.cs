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
        public IActionResult AddProduct(AddProductDto addProductDto)
        {
            var product = new Product()
            {
                ProductName = addProductDto.ProductName,
                CategoryID = addProductDto.CategoryID,
                Price = addProductDto.Price,
                Stock = addProductDto.Stock,
                CreatedAt = addProductDto.CreatedAt,
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
        public IActionResult UpdateProduct(int id,UpdateProductDto updateProductDto)
        {
            var product = dbContext.Products.Find(id);
            if(product is null)
            {
                return NotFound();
            }
            product.ProductName = updateProductDto.ProductName;
            product.CategoryID = updateProductDto.CategoryID;
            product.Price = updateProductDto.Price;
            product.Stock = updateProductDto.Stock;
            product.CreatedAt = updateProductDto.CreatedAt;

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
