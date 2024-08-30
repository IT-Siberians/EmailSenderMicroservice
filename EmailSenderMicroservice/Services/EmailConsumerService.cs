using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services;
using EmailSenderMicroservice.Application.Services.Abstraction;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace EmailSenderMicroservice.Services
{
    public class EmailConsumerService : BackgroundService
    {
        private readonly SenderService _sender;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName = "emailQueue";

        public EmailConsumerService(ISettingService settingService, IMessageService messageService)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; // пока типа локально
            _sender = new SenderService(settingService, messageService);            
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailRequest = JsonSerializer.Deserialize<MessageRequest>(message);

                //var test = _sender.SendAsync("vasya", "pophas123@mail.ru", "Важное уведомление", "что-то какой-то текст", true);

                var result = _sender.SendAsync(emailRequest.Name, emailRequest.Email, emailRequest.MessageType, emailRequest.MessageText, true);

                await Task.CompletedTask;
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
