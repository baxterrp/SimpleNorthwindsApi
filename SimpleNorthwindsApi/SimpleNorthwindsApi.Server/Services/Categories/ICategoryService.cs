using SimpleNorthwindsApi.Common;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.Server.Services.Categories
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category FindCategoryById(string id);
        void AddNewCategory(Category category);
        void DeleteCategory(string id);
        void UpdateCategory(Category category);
    }
}
