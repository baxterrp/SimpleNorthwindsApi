using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.DataEntities;
using SimpleNorthwindsApi.DataStores;
using SimpleNorthwindsApi.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleNorthwindsApi.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper<Customer, CustomerDataEntity> _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper<Customer, CustomerDataEntity> mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        /// <summary>
        /// Implements <see cref="ICustomerService.AddNewCustomer(Customer)"/>
        /// </summary>
        /// <param name="customer"><see cref="Customer"/></param>
        public async Task AddNewCustomer(Customer customer)
        {
            var customerEntity = _mapper.MapFrom(customer);

            await _customerRepository.InsertNewCustomer(customerEntity);
        }

        /// <summary>
        /// Implements <see cref="ICustomerService.GetAllCustomers"/>
        /// </summary>
        /// <returns><see cref="IEnumerable{T}"/> of <see cref="Customer"/></returns>
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.SelectAllCustomers();
                
            return customers.Select(customer => _mapper.MapTo(customer));
        }

        /// <summary>
        /// Implements <see cref="ICustomerService.GetCustomerById(string)"/>
        /// </summary>
        /// <param name="id">Unique id of <see cref="Customer"/></param>
        /// <returns><see cref="Customer"/></returns>
        public async Task<Customer> GetCustomerById(string id)
        {
            return _mapper.MapTo(await _customerRepository.SelectCustomerById(id));
        }
    }
}
