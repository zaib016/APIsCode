using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetail.Data;
using OnlineRetail.Models;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public OrderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(dbContext.Orders.ToList());
        }
        [HttpPost]
        public IActionResult AddOrder(OrderDto orderDto)
        {
            var order = new Order()
            {
                CustomerID = orderDto.CustomerID,
                OrderDate = orderDto.OrderDate,
                TotalAmount = orderDto.TotalAmount,
            };
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return Ok(order);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrderByID(int id)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            return Ok(order);

        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateOrder(int id, OrderDto orderDto)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            order.CustomerID = orderDto.CustomerID;
            order.OrderDate = orderDto.OrderDate;
            order.TotalAmount = orderDto.TotalAmount;

            dbContext.SaveChanges();
            return Ok(order);

        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = dbContext.Orders.Find(id);
            if(order is null)
            {
                return NotFound();
            }
            dbContext.Orders.Remove(order);
            return Ok(order);
        }
        
    }
}
