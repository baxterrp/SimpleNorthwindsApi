using Microsoft.AspNetCore.Mvc;
using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Services.Categories;
using System;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();

            return Ok(categories);
        }

        [HttpGet("/categories/{id}")]
        public async Task<IActionResult> FindCategoryById([FromRoute]string id)
        {
            var category = await _categoryService.FindCategoryById(id);

            return Ok(category);
        }

        [HttpPost("/categories")]
        public async Task<IActionResult> AddNewCategory([FromBody]Category category)
        {
            await _categoryService.AddNewCategory(category);

            return Ok();
        }

        [HttpDelete("/categories/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]string id)
        {
            await _categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}
