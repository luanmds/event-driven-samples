using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace UrlShortened.Api.Domain.ValueObject
{
    public class UrlGenerator
    {
        public static string GenerateShortUrl(HttpRequest request)
        {
            var uri = $"{request.Scheme}://{request.Host}";
            var urlCode = 
            
            return "";
        }
    }
}