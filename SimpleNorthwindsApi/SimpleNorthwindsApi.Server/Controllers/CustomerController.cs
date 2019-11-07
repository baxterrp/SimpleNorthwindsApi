using Microsoft.AspNetCore.Mvc;
using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.Services.Customers;
using System;

namespace SimpleNorthwindsApi.Server.Controllers
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
        public IActionResult AddNewCustomer([FromBody]Customer customer)
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

        [HttpPut("/customers/{id}")]
        public IActionResult UpdateCustomer([FromRoute]string id, [FromBody]Customer customer)
        {
            // I did this to show you can pass data via route and body in one request
            customer.Id = id;

            _customerService.UpdateCustomer(customer);

            return Ok();
        }
    }
}