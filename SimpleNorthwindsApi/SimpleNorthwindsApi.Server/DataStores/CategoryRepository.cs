using Dapper;
using SimpleNorthwindsApi.Server.Configuration;
using SimpleNorthwindsApi.Server.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindsConfiguration _northwindsConfiguration;

        public CategoryRepository(NorthwindsConfiguration northwindsConfiguration)
        {
            _northwindsConfiguration = northwindsConfiguration ?? throw new ArgumentNullException(nameof(northwindsConfiguration));
        }

        public async Task DeleteCategory(string id)
        {
            var sql = "DELETE FROM Categories WHERE [CategoryId] = @Id";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task InsertCategory(CategoryDataEntity category)
        {
            var sql = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                await connection.ExecuteAsync(sql, category);
            }
        }

        public async Task<IEnumerable<CategoryDataEntity>> SelectAllCategories()
        {
            var sql = "SELECT * FROM Categories";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                return await connection.QueryAsync<CategoryDataEntity>(sql);
            }
        }

        public async Task<CategoryDataEntity> SelectCategoryById(string id)
        {
            var sql = "SELECT * FROM Categories WHERE [CategoryId] = @Id";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                return await connection.QuerySingleAsync<CategoryDataEntity>(sql, new { Id = id });
            }
        }
    }
}
