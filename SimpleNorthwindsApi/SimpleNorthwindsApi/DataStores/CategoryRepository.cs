using SimpleNorthwindsApi.DataEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.DataStores
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task DeleteCategory(string id)
        {
            throw new NotImplementedException();
        }

        public Task InsertCategory(CategoryDataEntity category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDataEntity>> SelectAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDataEntity> SelectCategoryById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
