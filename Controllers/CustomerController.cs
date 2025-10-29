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
        public IActionResult AddCustomer(AddCustomerDto addCustomerDto)
        {
            var customer = new Customer()
            {
                FirstName = addCustomerDto.FirstName,
                LastName = addCustomerDto.LastName,
                Email = addCustomerDto.Email,
                Phone = addCustomerDto.Phone,
                Country = addCustomerDto.Country,
                City = addCustomerDto.City,
                Address = addCustomerDto.Address,
                CreatedAt = addCustomerDto.CreatedAt,
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
        public IActionResult updateCustomerData(int id, UpdateCustomerDto updateCustomerDto )
        {
            var customer = dbContext.Customers.Find(id);

            if(customer == null)
            {
                return NotFound();
            }

            customer.FirstName = updateCustomerDto.FirstName;
            customer.LastName = updateCustomerDto.LastName;
            customer.Email = updateCustomerDto.Email;
            customer.Phone = updateCustomerDto.Phone;
            customer.Country = updateCustomerDto.Country;
            customer.City = updateCustomerDto.City;
            customer.Address = updateCustomerDto.Address;
            customer.CreatedAt = updateCustomerDto.CreatedAt;

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
