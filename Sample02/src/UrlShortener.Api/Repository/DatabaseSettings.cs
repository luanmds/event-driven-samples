namespace UrlShortened.Api.Repository
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UrlsCollectionName { get; set; } = null!;
    }
}