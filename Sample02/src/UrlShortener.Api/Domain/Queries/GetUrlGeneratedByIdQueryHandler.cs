using System.Threading.Tasks;
using UrlShortened.Api.Domain.Entities;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Domain.Queries
{
    public class GetUrlGeneratedByIdQueryHandler
    {
        private MongoRepository _repository;

        public GetUrlGeneratedByIdQueryHandler(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetUrlGeneratedByIdQuery> HandleAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            
            return new GetUrlGeneratedByIdQuery()
            {
                ShortenedUrl = entity.UrlCode
            };
        }
    }
}