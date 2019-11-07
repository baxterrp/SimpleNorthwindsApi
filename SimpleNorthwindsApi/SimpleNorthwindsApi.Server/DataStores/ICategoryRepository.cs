using SimpleNorthwindsApi.Server.DataEntities;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDataEntity> SelectAllCategories();
        CategoryDataEntity SelectCategoryById(string id);
        void InsertCategory(CategoryDataEntity category);
        void DeleteCategory(string id);
        void UpdateCategory(CategoryDataEntity category);
    }
}
