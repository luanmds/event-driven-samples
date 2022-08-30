using System;
using CustomerManagement.Api.Domain.Model;

namespace CustomerManagement.Api.Domain.Events
{
    public class CustomerCreatedEvent : Event<Customer>
    {
        public CustomerCreatedEvent()
        {
            EventId = new Guid().ToString();
            EventName = "CustomerCreated";
        }
    }
}