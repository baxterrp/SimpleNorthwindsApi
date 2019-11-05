using SimpleNorthwindsApi.Server.DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDataEntity>> SelectAllCategories();
        Task<CategoryDataEntity> SelectCategoryById(string id);
        Task InsertCategory(CategoryDataEntity category);
        Task DeleteCategory(string id);
    }
}
