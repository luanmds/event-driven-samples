using System;
using CustomerManagement.Api.Domain.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace CustomerManagement.Api.Domain.Events
{
    [BsonDiscriminator("CustomerUpdatedEvent")]
    public class CustomerUpdatedEvent : Event<Customer>
    {
        private new const string EventName = "CustomerUpdated";

        public CustomerUpdatedEvent(string eventId, Customer eventData) :
            base(eventId, EventName, eventData.CustomerId, eventData)
        {

        }
    }
}