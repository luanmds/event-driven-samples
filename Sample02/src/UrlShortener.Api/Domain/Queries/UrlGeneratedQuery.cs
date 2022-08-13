using UrlShortened.Api.Domain.Entities;

namespace UrlShortened.Api.Domain.Queries
{
    public class UrlGeneratedQuery : IQuery<UrlGeneratedQuery>
    {
        public string ShortenedUrl { get; set; }

        public static UrlGeneratedQuery ParseEntityToQuery(ShortURL entity)
        {
            return new UrlGeneratedQuery()
            {
                ShortenedUrl = entity.UrlCode
            };
        }
    }
}