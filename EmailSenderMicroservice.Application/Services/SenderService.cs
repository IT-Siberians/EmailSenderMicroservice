using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services.Abstraction;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;


namespace EmailSenderMicroservice.Application.Services
{
    public class SenderService
    {
        private readonly ISettingService _settingService;
        private readonly IMessageService _messageService;
        private const string fromName = "Email Notification Service";

        public SenderService(ISettingService setting, IMessageService message)
        {
            _settingService = setting;
            _messageService = message;
        }        

        public async Task SendAsync(string toName, string toEmail, string subject, string text, bool isHtml)
        {
            var settingNow = await _settingService.GetCurrentAsync();

            var messageSend = new AddMessageModel(toEmail, subject, text);

            await _messageService.AddAsync(messageSend);

            var message = new MimeMessage()
            {
                Subject = subject,
                Body = new TextPart(isHtml ? "html" : "plain")
                {
                    Text = text
                }
            };
            message.From.Add(new MailboxAddress(fromName, settingNow.Login));
            message.To.Add(new MailboxAddress(toName, toEmail));

            var result = string.Empty;

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(settingNow.ServerAddress, Convert.ToInt32(settingNow.ServerPort), (settingNow.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None));
                await client.AuthenticateAsync(settingNow.Login, settingNow.Password);
                result = await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }

            result.Trim();

        }

    }
}
