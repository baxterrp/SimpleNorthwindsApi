using SimpleNorthwindsApi.DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.DataStores
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDataEntity>> SelectAllCustomers();
        Task<CustomerDataEntity> SelectCustomerById(string id);
        Task InsertNewCustomer(CustomerDataEntity customer);
    }
}
