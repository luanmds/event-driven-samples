using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace EventDriven.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SenderController : ControllerBase
    {
        private readonly ILogger<SenderController> _logger;

        public SenderController(ILogger<SenderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult SendMessage(string message)
        {
            _logger.LogInformation("Sending new message...");

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://root:root@rabbitmq:5672");

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello-queue",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "amq.direct",
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
            
            return Ok("Message Sending Successfully!");
        }
    }
}
