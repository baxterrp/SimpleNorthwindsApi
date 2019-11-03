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

        /// <summary>
        /// Returns a single <see cref="Common.Customer"/> by id/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/customers/{id}")]
        public async Task<IActionResult> FindCustomerById([FromRoute]string id)
        {
            var customer = await _customerService.GetCustomerById(id);

            return Ok(customer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        [HttpPost("/customers")]
        public async Task<IActionResult> AddNewCustomer([FromBody]Common.Customer customer)
        {
            await _customerService.AddNewCustomer(customer);

            return Ok();
        }
    }
}