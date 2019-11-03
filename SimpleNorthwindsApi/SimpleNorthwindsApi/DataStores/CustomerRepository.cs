using Dapper;
using Microsoft.Data.SqlClient;
using SimpleNorthwindsApi.Configuration;
using SimpleNorthwindsApi.DataEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.DataStores
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindsConfiguration _configuration;

        public CustomerRepository(NorthwindsConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<CustomerDataEntity>> SelectAllCustomers()
        {
            var sql = "SELECT * FROM Customers";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return await connection.QueryAsync<CustomerDataEntity>(sql) ?? new List<CustomerDataEntity>();
            }
        }
    }
}
