using SimpleNorthwindsApi.DataEntities;
using System.Collections.Generic;

namespace SimpleNorthwindsApi.DataStores
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDataEntity> SelectAllCustomers();
        CustomerDataEntity SelectCustomerById(string id);
        void InsertNewCustomer(CustomerDataEntity customer);
        void DeleteCustomer(string id);
    }
}
