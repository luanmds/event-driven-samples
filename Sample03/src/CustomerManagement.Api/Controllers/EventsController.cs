using CustomerManagement.Api.Domain.Events;
using CustomerManagement.Api.Domain.Model;
using CustomerManagement.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly EventRepository _eventRepository;

        public EventsController(ILogger<EventsController> logger, EventRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Event<Customer>>> GetEventByCustomer([FromQuery] string customerId)
        {
            var events = await _eventRepository.GetByCustomerIdKeyAsync(customerId);
            return events;
        }
    }
}
