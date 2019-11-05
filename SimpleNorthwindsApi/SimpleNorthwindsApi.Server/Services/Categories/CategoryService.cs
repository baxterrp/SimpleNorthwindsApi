using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.DataEntities;
using SimpleNorthwindsApi.Server.DataStores;
using SimpleNorthwindsApi.Server.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddNewCategory(Category category)
        {
            _categoryRepository.InsertCategory(_mapper.MapFrom(category)); 
        }

        public void DeleteCategory(string id)
        {
             _categoryRepository.DeleteCategory(id);
        }

        public Category FindCategoryById(string id)
        {
            var category = _categoryRepository.SelectCategoryById(id);

            return _mapper.MapTo(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _categoryRepository.SelectAllCategories();

            return categories.Select(category => _mapper.MapTo(category));
        }
    }
}
