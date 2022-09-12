using CustomerManagement.Api.Domain.Events;
using CustomerManagement.Api.Domain.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CustomerManagement.Api.Repository
{
    public class MongoRepository
    {
        public IMongoCollection<Customer> _customersCollection;
        public IMongoCollection<Event<Customer>> _eventsCollection;
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            _mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            _mongoDatabase = _mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _customersCollection = _mongoDatabase.GetCollection<Customer>(
                databaseSettings.Value.CustomerCollectionName);
            
            _eventsCollection = _mongoDatabase.GetCollection<Event<Customer>>(
                databaseSettings.Value.EventCollectionName);
        }
    }
}