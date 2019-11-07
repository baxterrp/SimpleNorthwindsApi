using SimpleNorthwindsApi.Server.DataEntities;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDataEntity> SelectAllCustomers();
        CustomerDataEntity SelectCustomerById(string id);
        void InsertNewCustomer(CustomerDataEntity customer);
        void DeleteCustomer(string id);
        void UpdateCustomer(CustomerDataEntity customer);
    }
}
