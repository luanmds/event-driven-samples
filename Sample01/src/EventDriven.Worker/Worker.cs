using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventDriven.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;          

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Waiting new messages...");

            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://root:root@rabbitmq:5672");

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "hello-queue",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Message Received: " + message);
                _logger.LogInformation($"Message Received >> {message}");
            };

            channel.BasicConsume(queue: "hello-queue",
                                autoAck: true,
                                consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Worker received in: {DateTime.Now}");
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
