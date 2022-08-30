namespace CustomerManagement.Api.Domain.Events
{
    public abstract class Event<T>
    {
        public string EventId;
        public string EventName;
        public string PartitionKey;
        public T EventData;
    }
}