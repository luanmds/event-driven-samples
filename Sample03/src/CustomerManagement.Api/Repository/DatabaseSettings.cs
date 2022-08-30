namespace CustomerManagement.Api.Repository
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string CustomerCollectionName { get; set; } = null!;

        public string EventCollectionName { get; set; } = null!;
    }
}