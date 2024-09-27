using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace EmailSenderMicroservice.Services
{
    public class EmailConsumerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly string _connectionString;

        public EmailConsumerService(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _serviceScopeFactory = serviceScopeFactory;

            _connectionString = configuration.GetValue<string>("RabbitMQ:ConnectionString")
                ?? throw new ArgumentNullException("Connection string for RabbitMQ is not configured.");

            _queueName = configuration.GetValue<string>("RabbitMQ:QueueName")
                ?? throw new ArgumentNullException("Queue name for RabbitMQ is not configured.");

            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_connectionString)
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                queue: _queueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var emailRequest = JsonSerializer.Deserialize<MessageRequest>(message);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var senderService = scope.ServiceProvider.GetRequiredService<SenderService>();

                    await senderService.SendAsync(emailRequest!.Name, emailRequest.Email, emailRequest.MessageType, emailRequest.MessageText, true, cancellationToken);
                }

                await Task.CompletedTask;
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Close();
            _connection.Close();
            return base.StopAsync(cancellationToken);
        }
    }
}