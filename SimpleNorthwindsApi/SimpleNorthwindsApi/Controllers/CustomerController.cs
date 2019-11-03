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

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns><see cref="IActionResult"/></returns>
        [HttpGet("/customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();

            return Ok(customers);
        }
    }
}