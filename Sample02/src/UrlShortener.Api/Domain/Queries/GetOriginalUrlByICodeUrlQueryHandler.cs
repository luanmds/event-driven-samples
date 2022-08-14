using System.Threading.Tasks;
using UrlShortened.Api.Domain.Entities;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Domain.Queries
{
    public class GetOriginalUrlByCodeUrlQueryHandler
    {
        private MongoRepository _repository;

        public GetOriginalUrlByCodeUrlQueryHandler(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOriginalUrlByCodeUrlQuery> HandleAsync(string code)
        {
            var entity = await _repository.GetAsync(code);
            
            return new GetOriginalUrlByCodeUrlQuery()
            {
                OriginalUrl = entity.OriginalURL
            };
        }
    }
}