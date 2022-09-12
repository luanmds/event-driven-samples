using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CustomerManagement.Api.Domain.Events
{
    public class Event<T>
    {
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string PartitionKey { get; set; }
        public T EventData { get; set; }

        public Event(string eventId, string eventName, string partitionKey, T eventData)
        {
            EventId = eventId;
            EventName = eventName;
            PartitionKey = partitionKey;
            EventData = eventData;
        }
    }
}