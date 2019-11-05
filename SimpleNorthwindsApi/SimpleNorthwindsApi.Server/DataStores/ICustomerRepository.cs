using SimpleNorthwindsApi.Server.DataEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Server.DataStores
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDataEntity>> SelectAllCustomers();
        Task<CustomerDataEntity> SelectCustomerById(string id);
        Task InsertNewCustomer(CustomerDataEntity customer);
        Task DeleteCustomer(string id);
    }
}
