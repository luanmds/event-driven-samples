using CustomerManagement.Api.Domain.Model;
using System;

namespace CustomerManagement.Api.DTO
{
    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Customer ToDomainObject()
            => new Customer()
            {
                CustomerId = Guid.NewGuid().ToString(),
                Name = Name,
                Age = Age,
                Address = Address,
                Status = CustomerStatus.ACTIVATED,
                CreatedAt = DateTime.UtcNow
            };
    }
}