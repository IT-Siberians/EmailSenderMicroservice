using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.Interface.Service;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace EmailSenderMicroservice.Application.Services
{
    public class SenderService
    {
        private readonly ISettingService _setting;
        private readonly IMessageService _message;
        private const string fromName = "Email Notification Service";

        public SenderService(ISettingService setting, IMessageService message)
        {
            _setting = setting;
            _message = message;
        }        

        public async Task SendAsync(string toName, string toEmail, string subject, string text, bool isHtml)
        {
            var settingNow = await _setting.GetAsync();

            var messageDomain = new Message(Guid.NewGuid(), toEmail, subject, text, true, DateTime.UtcNow);
            

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, settingNow.Login.Value));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;
            message.Body = new TextPart(isHtml ? "html" : "plain")
            {
                Text = text
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(settingNow.ServerAddress, (int)settingNow.ServerPort, (settingNow.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None));
                await client.AuthenticateAsync(settingNow.Login.Value, settingNow.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            await _message.AddAsync(messageDomain);

        }

    }
}
