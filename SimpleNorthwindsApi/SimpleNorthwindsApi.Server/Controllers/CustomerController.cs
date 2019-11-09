using Microsoft.AspNetCore.Mvc;
using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.Services.Customers;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }

        [HttpGet("/customers/{id}")]
        public async Task<IActionResult> FindCustomerById([FromRoute]string id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return Ok(customer);
        }

        [HttpPost("/customers")]
        public async Task<IActionResult> AddNewCustomer([FromBody]Customer customer)
        {
            await _customerService.AddNewCustomer(customer);

            return Ok();
        }

        [HttpDelete("/customers/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]string id)
        {
            await _customerService.DeleteCustomer(id);

            return Ok();
        }

        [HttpPut("/customers/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]string id, [FromBody]Customer customer)
        {
            // I did this to show you can pass data via route and body in one request
            customer.Id = id;

            await _customerService.UpdateCustomer(customer);

            return Ok();
        }
    }
}