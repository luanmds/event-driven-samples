using System;
using CustomerManagement.Api.Domain.Model;

namespace CustomerManagement.Api.Domain.Events
{
    public class CustomerUpdatedEvent:  Event<Customer>
    {
        public CustomerUpdatedEvent()
        {
            EventId = new Guid().ToString();
            EventName = "CustomerUpdated";
        }
    }
}