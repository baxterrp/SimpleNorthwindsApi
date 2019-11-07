using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.Server.DataEntities;
using SimpleNorthwindsApi.Server.DataStores;
using SimpleNorthwindsApi.Server.Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNorthwindsApi.Server.Services.Customers
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

        public ICustomerRepository CustomerRepository => _customerRepository;

        public void AddNewCustomer(Customer customer)
        {
            var customerEntity = _mapper.MapFrom(customer);

            _customerRepository.InsertNewCustomer(customerEntity);
        }

        public void DeleteCustomer(string id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _customerRepository.SelectAllCustomers();
                
            return customers.Select(customer => _mapper.MapTo(customer));
        }

        public Customer GetCustomerById(string id)
        {
            return _mapper.MapTo(_customerRepository.SelectCustomerById(id));
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(_mapper.MapFrom(customer));
        }
    }
}
