using SimpleNorthwindsApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> FindCategoryById(string id);
        Task AddNewCategory(Category category);
        Task DeleteCategory(string id);
    }
}
