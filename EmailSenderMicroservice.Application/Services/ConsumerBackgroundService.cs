using EmailSenderMicroservice.Application.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmailSenderMicroservice.Application.Services
{
    public class ConsumerBackgroundService : BackgroundService
    {
        private readonly SenderService _sender;
        private readonly ILogger<ConsumerBackgroundService> _logger;

        public ConsumerBackgroundService(ISettingService setting, IMessageService message, ILogger<ConsumerBackgroundService> logger)
        {
            _sender = new SenderService(setting, message); 
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _sender.SendAsync("vasya","pophas123@mail.ru","Важное уведомление","что-то какой-то текст",true);


            return Task.CompletedTask;
        }
    }
}
