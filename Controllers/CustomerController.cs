using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetail.Data;
using OnlineRetail.Models;
using OnlineRetail.Models.Entities;

namespace OnlineRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ApplicationDbContext dbContext;

        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(dbContext.Customers.ToList());
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerDto customerDto)
        {
            var customer = new Customer()
            {
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Email = customerDto.Email,
                Phone = customerDto.Phone,
                Country = customerDto.Country,
                City = customerDto.City,
                Address = customerDto.Address,
                CreatedAt = customerDto.CreatedAt,
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return Ok();

        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCustomerByID(int id)
        {
            var customer = dbContext.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult updateCustomerData(int id, CustomerDto customerDto)
        {
            var customer = dbContext.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();
            }

            customer.FirstName = customerDto.FirstName;
            customer.LastName = customerDto.LastName;
            customer.Email = customerDto.Email;
            customer.Phone = customerDto.Phone;
            customer.Country = customerDto.Country;
            customer.City = customerDto.City;
            customer.Address = customerDto.Address;
            customer.CreatedAt = customerDto.CreatedAt;

            dbContext.SaveChanges();
            return Ok(customer);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = dbContext.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();
            }

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();

            return Ok(customer);
        }
    }
}
