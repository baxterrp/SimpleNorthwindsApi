using Microsoft.AspNetCore.Mvc;
using SimpleNorthwindsApi.Services.Customers;
using System;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet("/customers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("/customers/{id}")]
        public IActionResult FindCustomerById([FromRoute]string id)
        {
            var customer = _customerService.GetCustomerById(id);

            return Ok(customer);
        }

        [HttpPost("/customers")]
        public IActionResult AddNewCustomer([FromBody]Common.Customer customer)
        {
            _customerService.AddNewCustomer(customer);

            return Ok();
        }

        [HttpDelete("/customers/{id}")]
        public IActionResult DeleteCustomer([FromRoute]string id)
        {
            _customerService.DeleteCustomer(id);

            return Ok();
        }
    }
}