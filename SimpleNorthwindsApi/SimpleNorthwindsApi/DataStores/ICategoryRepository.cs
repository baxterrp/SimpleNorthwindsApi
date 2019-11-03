using SimpleNorthwindsApi.DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.DataStores
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDataEntity>> SelectAllCategories();
        Task<CategoryDataEntity> SelectCategoryById(string id);
        Task InsertCategory(CategoryDataEntity category);
        Task DeleteCategory(string id);
    }
}
