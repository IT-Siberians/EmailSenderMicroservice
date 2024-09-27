using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services.Abstraction;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace EmailSenderMicroservice.Application.Services
{
    /// <summary>
    /// Служба для отправки электронных писем.
    /// </summary>
    /// <param name="settingService">Служба для получения настроек электронной почты.</param>
    /// <param name="messageService">Служба для управления сообщениями.</param>
    public class SenderService(ISettingService settingService, IMessageService messageService)
    {
        private const string FromName = "Email Notification Service";

        /// <summary>
        /// Отправляет электронное письмо.
        /// </summary>
        /// <param name="toName">Имя получателя.</param>
        /// <param name="toEmail">Адрес электронной почты получателя.</param>
        /// <param name="subject">Тема письма.</param>
        /// <param name="text">Текст письма.</param>
        /// <param name="isHtml">Указывает, является ли текст письма HTML-контентом.</param>
        /// <returns>Асинхронная задача.</returns>
        /// <exception cref="InvalidOperationException">Выбрасывается, если не удается получить текущие настройки.</exception>
        public async Task SendAsync(string toName, string toEmail, string subject, string text, bool isHtml, CancellationToken cancellationToken)
        {
            var settingNow = await settingService.GetCurrentAsync(cancellationToken);
            if (settingNow is null)
            {
                throw new InvalidOperationException("Не удалось получить текущие настройки для отправки письма.");
            }

            var messageSend = new AddMessageModel(toEmail, subject, text);
            await messageService.AddAsync(messageSend, cancellationToken);

            var message = new MimeMessage
            {
                Subject = subject,
                Body = new TextPart(isHtml ? "html" : "plain")
                {
                    Text = text
                }
            };
            message.From.Add(new MailboxAddress(FromName, settingNow.Login));
            message.To.Add(new MailboxAddress(toName, toEmail));

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(settingNow.ServerAddress, Convert.ToInt32(settingNow.ServerPort),
                    settingNow.UseSSL ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.None);
                await client.AuthenticateAsync(settingNow.Login, settingNow.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
