using CustomerManagement.Api.Domain.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerManagement.Api.Domain.Events
{
    [BsonDiscriminator("CustomerDeactivatedEvent")]
    public class CustomerDeactivatedEvent : Event<Customer>
    {
        private new const string EventName = "CustomerDeactivated";

        public CustomerDeactivatedEvent(string eventId, Customer eventData) :
            base(eventId, EventName, eventData.CustomerId, eventData)
        {

        }
    }
}
