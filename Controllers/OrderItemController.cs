using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetail.Data;
using OnlineRetail.Models;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public OrderItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetOrderItemList()
        {
            return Ok(dbContext.OrderItems.ToList());
        }
        [HttpPost]
        public IActionResult AddOrderItem(AddOrderItemDto addOrderItemDto)
        {
            var orderItem = new OrderItem()
            {
                OrderID = addOrderItemDto.OrderID,
                ProductID = addOrderItemDto.ProductID,
                Quantity = addOrderItemDto.Quantity,
                Price = addOrderItemDto.Price,
            };
            dbContext.OrderItems.Add(orderItem);
            dbContext.SaveChanges();

            return Ok(orderItem);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrderItemByID(int id)
        {
            var item = dbContext.OrderItems.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateOrderItem(int id, UpdateOrderItem updateOrderItem)
        {
            var item = dbContext.OrderItems.Find(id);
            if(item is null)
            {
                return NotFound();
            }
            item.OrderID = updateOrderItem.OrderID;
            item.ProductID = updateOrderItem.ProductID;
            item.Quantity = updateOrderItem.Quantity;
            item.Price = updateOrderItem.Price;

            dbContext.SaveChanges();
            return Ok(item);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrderItem(int id)
        {
            var item = dbContext.OrderItems.Find(id);
            if(item is null)
            {
                return NotFound();
            }
            dbContext.OrderItems.Remove(item);
            dbContext.SaveChanges();

            return Ok(item);
        }
    }
}
