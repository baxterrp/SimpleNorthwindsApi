﻿using Dapper;
using Microsoft.Data.SqlClient;
using SimpleNorthwindsApi.Configuration;
using SimpleNorthwindsApi.DataEntities;
using System;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.DataStores
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindsConfiguration _northwindsConfiguration;

        public CategoryRepository(NorthwindsConfiguration northwindsConfiguration)
        {
            _northwindsConfiguration = northwindsConfiguration ?? throw new ArgumentNullException(nameof(northwindsConfiguration));
        }

        public void DeleteCategory(string id)
        {
            var sql = "DELETE FROM Categories WHERE [CategoryId] = @Id";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        public void InsertCategory(CategoryDataEntity category)
        {
            var sql = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description)";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                connection.Execute(sql, category);
            }
        }

        public IEnumerable<CategoryDataEntity> SelectAllCategories()
        {
            var sql = "SELECT * FROM Categories";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                return connection.Query<CategoryDataEntity>(sql);
            }
        }

        public CategoryDataEntity SelectCategoryById(string id)
        {
            var sql = "SELECT * FROM Categories WHERE [CategoryId] = @Id";

            using (var connection = new SqlConnection(_northwindsConfiguration.ConnectionString))
            {
                return connection.QuerySingle<CategoryDataEntity>(sql, new { Id = id });
            }
        }
    }
}
