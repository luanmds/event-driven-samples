using System.Threading.Tasks;
using UrlShortened.Api.Domain.Entities;
using UrlShortened.Api.Repository;

namespace UrlShortened.Api.Domain.Queries
{
    public class UrlGeneratedQueryHandler
    {
        private MongoRepository _repository;

        public UrlGeneratedQueryHandler(MongoRepository repository)
        {
            _repository = repository;
        }

        public async Task<UrlGeneratedQuery> HandleAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return UrlGeneratedQuery.ParseEntityToQuery(entity);
        }
    }
}