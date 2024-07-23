using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    internal interface IMessageRepository : IBaseRepository<Message, Guid>
    {
    }
}
