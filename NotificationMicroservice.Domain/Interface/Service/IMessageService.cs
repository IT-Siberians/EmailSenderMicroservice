using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    internal interface IMessageService :IBaseService<Message, Guid>
    {
    }
}
