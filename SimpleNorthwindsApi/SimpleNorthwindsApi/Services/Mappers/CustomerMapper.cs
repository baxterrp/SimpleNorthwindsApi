using SimpleNorthwindsApi.Common;
using SimpleNorthwindsApi.DataEntities;
using System;

namespace SimpleNorthwindsApi.Services.Mappers
{
    public class CustomerMapper : IMapper<Customer, CustomerDataEntity>
    {
        public CustomerDataEntity MapFrom(Customer poco)
        {
            throw new NotImplementedException();
        }

        public Customer MapTo(CustomerDataEntity entity) => new Customer
        {
            Id = entity.CustomerId,
            Name = entity.ContactName,
            Company = entity.CompanyName,
            Title = entity.ContactTitle,
            Address = new Address
            {
                Street = entity.Address,
                City = entity.City,
                Region = entity.Region,
                Zip = entity.PostalCode,
                Country = entity.Country
            },
            Phone = entity.Phone,
            Fax = entity.Fax
        };
    }
}
