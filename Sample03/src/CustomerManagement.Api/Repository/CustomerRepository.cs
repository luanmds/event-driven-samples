using System.Threading.Tasks;
using CustomerManagement.Api.Domain.Events;
using CustomerManagement.Api.Domain.Model;
using MongoDB.Driver;

namespace CustomerManagement.Api.Repository
{
    public class CustomerRepository
    {
        private readonly MongoRepository _repository;

        public CustomerRepository(MongoRepository repository)
        {
            _repository = repository;
        }
        
        public async Task CreateAsync(Customer data) =>
            await _repository._customersCollection.InsertOneAsync(data);
        
        public async Task UpdateAsync(FilterDefinition<Customer> filter, UpdateDefinition<Customer> update) =>
            await _repository._customersCollection.UpdateOneAsync(filter, update);
    }
}