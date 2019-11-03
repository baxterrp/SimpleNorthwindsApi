using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.DataEntities;
using SimpleNorthwindsApi.DataStores;
using SimpleNorthwindsApi.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Services.Categories
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
            await _categoryRepository.InsertCategory(_mapper.MapFrom(category)); 
        }

        public async Task DeleteCategory(string id)
        {
            await _categoryRepository.DeleteCategory(id);
        }

        public async Task<Category> FindCategoryById(string id)
        {
            var category = await _categoryRepository.SelectCategoryById(id);

            return _mapper.MapTo(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _categoryRepository.SelectAllCategories();

            return categories.Select(category => _mapper.MapTo(category));
        }
    }
}
