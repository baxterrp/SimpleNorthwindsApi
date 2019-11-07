using Dapper;
using SimpleNorthwindsApi.Server.Configuration;
using SimpleNorthwindsApi.Server.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindsConfiguration _configuration;

        public CustomerRepository(NorthwindsConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void DeleteCustomer(string id)
        {
            var sql = "DELETE FROM Customers WHERE [CustomerId] = @Id";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                connection.Execute(sql, new { Id = id });
            }
        }

        public void InsertNewCustomer(CustomerDataEntity customer)
        {
            var sql = "INSERT INTO Customers (CustomerId, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax)" +
                " VALUES (@CustomerId, @ContactName, @CompanyName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax)";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                connection.Execute(sql, customer);
            }
        }

        public IEnumerable<CustomerDataEntity> SelectAllCustomers()
        {
            var sql = "SELECT * FROM Customers";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return connection.Query<CustomerDataEntity>(sql) ?? new List<CustomerDataEntity>();
            }
        }

        public CustomerDataEntity SelectCustomerById(string id)
        {
            var sql = "SELECT * FROM Customers WHERE [CustomerId] = @Id";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                return connection.QuerySingle<CustomerDataEntity>(sql, new { Id = id });
            }
        }

        public void UpdateCustomer(CustomerDataEntity customer)
        {
            var sql = "UPDATE Customers SET" +
                " [CompanyName] = @CompanyName," +
                " [ContactName] = @ContactName," +
                " [ContactTitle] = @ContactTitle," +
                " [Address] = @Address," +
                " [City] = @City," +
                " [Region] = @Region," +
                " [PostalCode] = @PostalCode," +
                " [Country] = @Country," +
                " [Phone] = @Phone," +
                " [Fax] = @Fax WHERE [CustomerId] = @CustomerId";

            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                connection.Execute(sql, customer);
            }
        }
    }
}
