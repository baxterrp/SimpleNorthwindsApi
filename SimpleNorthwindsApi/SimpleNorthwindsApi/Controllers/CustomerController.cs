using Microsoft.AspNetCore.Mvc;

namespace SimpleNorthwindsApi.Controllers
{
    public class CustomerController : ControllerBase
    {
        [HttpGet("/customers")]
        public IActionResult GetAllCustomers()
        {
            return Ok();
        }
    }
}