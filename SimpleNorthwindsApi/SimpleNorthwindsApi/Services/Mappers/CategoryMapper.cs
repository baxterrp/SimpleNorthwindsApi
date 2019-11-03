using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.DataEntities;

namespace SimpleNorthwindsApi.Services.Mappers
{
    public class CategoryMapper : IMapper<Category, CategoryDataEntity>
    {
        public CategoryDataEntity MapFrom(Category poco) => new CategoryDataEntity
        {
            CategoryId = poco.Id,
            CategoryName = poco.Name,
            Description = poco.Description
        };

        public Category MapTo(CategoryDataEntity entity) => new Category
        {
            Id = entity.CategoryId,
            Name = entity.CategoryName,
            Description = entity.Description
        };
    }
}
