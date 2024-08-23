using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Application.Services.Abstraction;
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

            var messageSend = new MessageAddModel(toEmail, subject, text);

            await _message.AddAsync(messageSend);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, settingNow.Login));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;
            message.Body = new TextPart(isHtml ? "html" : "plain")
            {
                Text = text
            };

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
