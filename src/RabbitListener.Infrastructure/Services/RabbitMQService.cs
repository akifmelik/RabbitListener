using RabbitListener.Domain.Contracts.Interfaces;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitListener.Infrastructure.Extensions
{
    public class RabbitMQService
    {
        private readonly IRequestService _requestService;
        public RabbitMQService(IRequestService requestService)
        {
            _requestService = requestService;

        }
        public void AddQueues()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "urls",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            Console.WriteLine(" [*] Waiting for messages.");

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var url = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {url}");

                await _requestService.Head(url);
            };

            channel.BasicConsume(queue: "urls",
                                 autoAck: true,
                                 consumer: consumer);
            Console.ReadLine();
        }
    }
}


