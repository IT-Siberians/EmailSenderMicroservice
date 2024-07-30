using EmailSenderMicroservice.Domain.Models;
using Microsoft.Extensions.Hosting;

namespace EmailSenderMicroservice.Application.Services
{
    public class ConsumerBackgroundService : BackgroundService
    {
        private readonly SenderService _sender;

        public ConsumerBackgroundService() {
            //_sender; // = new SenderService();
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _sender.SendAsync("vasya","pophas123@mail.ru","Важное уведомление","что-то какой-то текст",true);

            return Task.CompletedTask;
        }
    }
}
