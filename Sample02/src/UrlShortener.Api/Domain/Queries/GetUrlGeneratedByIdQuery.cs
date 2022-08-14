using UrlShortened.Api.Domain.Entities;

namespace UrlShortened.Api.Domain.Queries
{
    public class GetUrlGeneratedByIdQuery : IQuery<GetUrlGeneratedByIdQuery>
    {
        public string ShortenedUrl { get; set; }
    }
}