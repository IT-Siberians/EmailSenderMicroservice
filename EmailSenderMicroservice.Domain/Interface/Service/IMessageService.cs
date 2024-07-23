using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    internal interface IMessageService :IBaseService<Message, Guid>
    {
    }
}
