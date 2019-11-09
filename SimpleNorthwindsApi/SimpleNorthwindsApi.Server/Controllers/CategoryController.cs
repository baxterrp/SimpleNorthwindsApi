using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.Services.Categories;

namespace SimpleNorthwindsApi.Server.Controllers
{
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet("/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();

                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/categories/{id}")]
        public async Task<IActionResult> FindCategoryById([FromRoute]string id) 
        {
            try
            {
                var category = await _categoryService.FindCategoryById(id);

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("/categories")]
        public async Task<IActionResult> AddNewCategory([FromBody]Category category)
        {
            try
            {
                await _categoryService.AddNewCategory(category);

                return Ok();
            }
            catch 
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete("/categories/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]string id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/categories")]
        public async Task<IActionResult> UpdateCategory([FromBody]Category category)
        {
            try
            {
                await _categoryService.UpdateCategory(category);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
