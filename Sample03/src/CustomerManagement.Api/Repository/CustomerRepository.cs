using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<bool> UpdateAsync(FilterDefinition<Customer> filter, UpdateDefinition<Customer> update)
        {
            var result = await _repository._customersCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Customer>> GetAll() =>
            await _repository._customersCollection.Find(_ => true).ToListAsync();

        public async Task<Customer> GetByCustomerId(string customerId) =>
            await _repository._customersCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
    }
}