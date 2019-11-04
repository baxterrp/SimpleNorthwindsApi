using SimpleNorthwindsApi.DataEntities;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.DataStores
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDataEntity> SelectAllCategories();
        CategoryDataEntity SelectCategoryById(string id);
        void InsertCategory(CategoryDataEntity category);
        void DeleteCategory(string id);
    }
}
