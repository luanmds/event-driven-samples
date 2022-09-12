using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Api.Domain.DTO;
using CustomerManagement.Api.Domain.Events;
using CustomerManagement.Api.Domain.Model;
using CustomerManagement.Api.DTO;
using CustomerManagement.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly CustomerRepository _customerRepository;
        private readonly EventRepository _eventRepository;

        public CustomersController(ILogger<CustomersController> logger, 
            CustomerRepository customerRepository,
            EventRepository eventRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _eventRepository = eventRepository;            
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO dto)
        {
            var customer = dto.ToDomainObject();
            await _customerRepository.CreateAsync(customer);

            var @event = new CustomerCreatedEvent(Guid.NewGuid().ToString(), customer);
            await _eventRepository.CreateAsync(@event);

            return Accepted();
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(string customerId, [FromBody] UpdateCustomerDTO dto)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.CustomerId, customerId);
            var update = Builders<Customer>.Update
                .Set(x => x.Name, dto.Name)
                .Set(x => x.Age, dto.Age)
                .Set(x => x.Address, dto.Address);
            var updated = await _customerRepository.UpdateAsync(filter, update);

            if (updated) {
                var customer = await _customerRepository.GetByCustomerId(customerId);

                var @event = new CustomerUpdatedEvent(Guid.NewGuid().ToString(), customer);
                await _eventRepository.CreateAsync(@event);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeactivateCustomer(string customerId)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.CustomerId, customerId);
            var update = Builders<Customer>.Update.Set(x => x.Status, CustomerStatus.DEACTIVATED);
            var updated = await _customerRepository.UpdateAsync(filter, update);

            if (updated)
            {
                var customer = await _customerRepository.GetByCustomerId(customerId);

                var @event = new CustomerDeactivatedEvent(Guid.NewGuid().ToString(), customer);
                await _eventRepository.CreateAsync(@event);
                return Ok();
            }

            return NotFound();
        }
    }
}