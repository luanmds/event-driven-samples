using System;

namespace UrlShortened.Api.Domain.Entities
{
    public class ShortURL : Entity
    {
        public string OriginalURL { get; set; }
        public string UrlCode { get; set; }
        public DateTime CreatedAt { get; }

        public ShortURL()
        {
            CreatedAt = DateTime.Now;
        }

        public ShortURL(string originalUrl, string urlCode, DateTime createdAt)
        {
            OriginalURL = originalUrl;
            UrlCode = urlCode;
            CreatedAt = createdAt;
        }
    }
}