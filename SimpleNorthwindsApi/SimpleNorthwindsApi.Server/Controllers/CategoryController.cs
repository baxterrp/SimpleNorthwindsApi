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
        public IActionResult GetAllCategories() => Ok(_categoryService.GetAllCategories());

        [HttpGet("/categories/{id}")]
        public IActionResult FindCategoryById([FromRoute]string id) => Ok(_categoryService.FindCategoryById(id));

        [HttpPost("/categories")]
        public IActionResult AddNewCategory([FromBody]Category category)
        {
            _categoryService.AddNewCategory(category);

            return Ok();
        }

        [HttpDelete("/categories/{id}")]
        public IActionResult DeleteCategory([FromRoute]string id)
        {
            _categoryService.DeleteCategory(id);

            return Ok();
        }

        [HttpPut("/categories")]
        public IActionResult UpdateCategory([FromBody]Category category)
        {
            _categoryService.UpdateCategory(category);

            return Ok();
        }
    }
}
