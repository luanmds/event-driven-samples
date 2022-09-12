using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagement.Api.Domain.Events;
using CustomerManagement.Api.Domain.Model;
using MongoDB.Driver;

namespace CustomerManagement.Api.Repository
{
    public class EventRepository
    {
        private readonly MongoRepository _repository;

        public EventRepository(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Event<Customer>>> GetByCustomerIdKeyAsync(string customerId) =>
            await _repository._eventsCollection
                .Find(x => x.PartitionKey == customerId)
                .ToListAsync();

        public async Task CreateAsync(Event<Customer> data) =>
            await _repository._eventsCollection.InsertOneAsync(data);
    }
}