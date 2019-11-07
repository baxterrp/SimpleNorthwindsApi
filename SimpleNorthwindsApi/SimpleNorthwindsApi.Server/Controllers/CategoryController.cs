using System;
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
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();

                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/categories/{id}")]
        public IActionResult FindCategoryById([FromRoute]string id) 
        {
            try
            {
                var category = _categoryService.FindCategoryById(id);

                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("/categories")]
        public IActionResult AddNewCategory([FromBody]Category category)
        {
            try
            {
                _categoryService.AddNewCategory(category);

                return Ok();
            }
            catch 
            { 
                return BadRequest(); 
            }
        }

        [HttpDelete("/categories/{id}")]
        public IActionResult DeleteCategory([FromRoute]string id)
        {
            try
            {
                _categoryService.DeleteCategory(id);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/categories")]
        public IActionResult UpdateCategory([FromBody]Category category)
        {
            try
            {
                _categoryService.UpdateCategory(category);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
