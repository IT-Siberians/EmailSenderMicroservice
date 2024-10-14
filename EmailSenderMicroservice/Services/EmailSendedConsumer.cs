using EmailSenderMicroservice.Application.Services;
using MassTransit;
using Otus.QueueDto;

namespace EmailSenderMicroservice.Services
{
    public class EmailSendedConsumer(IServiceScopeFactory serviceScopeFactory, ILogger<EmailSendedConsumer> logger) : IConsumer<MessageEvent>
    {
        public async Task Consume(ConsumeContext<MessageEvent> context)
        {
            var message = context.Message;

            using var scope = serviceScopeFactory.CreateScope();
            var senderService = scope.ServiceProvider.GetRequiredService<SenderService>();

            var result = await senderService.SendAsync(message!.Name, message.Email, message.MessageType, message.MessageText, true);

            if (!result)
            {
                logger.LogWarning("Failed to send email, message will be redelivered.");
                await context.Redeliver(TimeSpan.FromSeconds(10));
            }

        }
    }
}
