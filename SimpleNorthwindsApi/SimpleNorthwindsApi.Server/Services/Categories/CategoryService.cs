using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.DataEntities;
using SimpleNorthwindsApi.Server.DataStores;
using SimpleNorthwindsApi.Server.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper<Category, CategoryDataEntity> _mapper;

        public CategoryService(IMapper<Category, CategoryDataEntity> mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddNewCategory(Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));
            if (string.IsNullOrWhiteSpace(category.Name)) throw new ArgumentException($"Must include a category name");

            await _categoryRepository.InsertCategory(_mapper.MapFrom(category));
        }

        public async Task DeleteCategory(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            await _categoryRepository.DeleteCategory(id);
        }

        public async Task<Category> FindCategoryById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var category = await _categoryRepository.SelectCategoryById(id);

            if (category is null) throw new InvalidOperationException($"No category found with id {id}");

            return _mapper.MapTo(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _categoryRepository.SelectAllCategories();

            if (!categories?.Any() ?? false) throw new InvalidOperationException($"No categories found");

            return categories.Select(category => _mapper.MapTo(category));
        }

        public async Task UpdateCategory(Category category)
        {
            if (category is null) throw new ArgumentNullException(nameof(category));
            if (string.IsNullOrWhiteSpace(category.Name)) throw new ArgumentException($"Category must have a name");

            await _categoryRepository.UpdateCategory(_mapper.MapFrom(category));
        }
    }
}
