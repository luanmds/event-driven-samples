using UrlShortened.Api.Domain.Entities;

namespace UrlShortened.Api.Domain.Queries
{
    public class GetOriginalUrlByCodeUrlQuery : IQuery<GetOriginalUrlByCodeUrlQuery>
    {
        public string OriginalUrl { get; set; }
    }
}