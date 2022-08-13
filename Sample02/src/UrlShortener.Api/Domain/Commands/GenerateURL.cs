using System;
using System.Threading.Tasks;
using UrlShortened.Api.Domain.Entities;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Domain.Commands
{
    public class GenerateURL : Command
    {
        private readonly MongoRepository _repository;

        public GenerateURL(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Shorten(string url)
        {
            var urlCode = GenerateUrlCode();
            var entity = new ShortURL()
            {
                OriginalURL = url,
                UrlCode = urlCode
            };
            
            await _repository.CreateAsync(entity);
            return entity.Id;
        }

        private string GenerateUrlCode()
        {
            return Guid.NewGuid().ToString().Substring(0,6);
        }
    }
}