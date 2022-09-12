using CustomerManagement.Api.Domain.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerManagement.Api.Domain.Events
{
    [BsonDiscriminator("CustomerCreatedEvent")]
    public class CustomerCreatedEvent : Event<Customer>
    {
        private new const string EventName = "CustomerCreated";

        public CustomerCreatedEvent(string eventId, Customer eventData) : 
            base(eventId, EventName, eventData.CustomerId, eventData)
        {
            
        }
    }
}