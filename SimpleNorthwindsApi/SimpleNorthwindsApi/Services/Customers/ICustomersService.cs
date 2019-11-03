using SimpleNorthwindsApi.Common;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.Services.Customers
{
    public interface ICustomersService
    {
        IEnumerable<Customer> GetAllCustomers(); 
    }
}
