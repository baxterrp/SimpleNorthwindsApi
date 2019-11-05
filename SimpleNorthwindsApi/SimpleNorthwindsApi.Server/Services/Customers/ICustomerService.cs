using SimpleNorthwindsApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(string id);
        Task AddNewCustomer(Customer customer);
        Task DeleteCustomer(string id);
    }
}
