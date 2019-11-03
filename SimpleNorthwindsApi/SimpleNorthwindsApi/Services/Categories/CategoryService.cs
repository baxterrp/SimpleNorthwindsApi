using SimpleNorthwindsApi.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        public Task AddNewCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindCategoryById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
