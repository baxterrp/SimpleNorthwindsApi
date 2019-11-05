using SimpleNorthwindsApi.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.Services.Customers
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(string id);
        void AddNewCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}
