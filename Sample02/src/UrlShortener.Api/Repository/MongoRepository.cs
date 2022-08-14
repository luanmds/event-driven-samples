using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UrlShortened.Api.Domain.Entities;

namespace UrlShortened.Api.Repository
{
    public class MongoRepository
    {
        private readonly IMongoCollection<ShortURL> _urlsCollection;
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoRepository(IOptions<DatabaseSettings> databaseSettings)
        {
            _mongoClient = new MongoClient(
                databaseSettings.Value.ConnectionString);

            _mongoDatabase = _mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _urlsCollection = _mongoDatabase.GetCollection<ShortURL>(
                databaseSettings.Value.UrlsCollectionName);
        }
        
        public async Task<ShortURL?> GetByIdAsync(string id) =>
            await _urlsCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        
        public async Task<ShortURL?> GetAsync(string urlCode) =>
            await _urlsCollection
                .Find(x => x.UrlCode == urlCode)
                .FirstOrDefaultAsync();

        public async Task CreateAsync(ShortURL url) =>
            await _urlsCollection.InsertOneAsync(url);
    }
}
