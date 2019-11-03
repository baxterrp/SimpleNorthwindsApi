using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok();
        }
    }
}
