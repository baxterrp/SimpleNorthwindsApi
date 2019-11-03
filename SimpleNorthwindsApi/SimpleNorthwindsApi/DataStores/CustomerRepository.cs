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

        public async Task DeleteCustomer(string id)
        {
            var sql = "DELETE FROM Customers WHERE [CustomerId] = @Id";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                await connection.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task InsertNewCustomer(CustomerDataEntity customer)
        {
            var sql = "INSERT INTO Customers (CustomerId, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)" +
                " VALUES (@CustomerId, @ContactName, @CompanyName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                await connection.ExecuteAsync(sql, customer);
            }
        }

        public async Task<IEnumerable<CustomerDataEntity>> SelectAllCustomers()
        {
            var sql = "SELECT * FROM Customers";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return await connection.QueryAsync<CustomerDataEntity>(sql) ?? new List<CustomerDataEntity>();
            }
        }

        public async Task<CustomerDataEntity> SelectCustomerById(string id)
        {
            var sql = "SELECT * FROM Customers WHERE [CustomerId] = @Id";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return await connection.QuerySingleAsync<CustomerDataEntity>(sql, new { Id = id });
            }
        }
    }
}
