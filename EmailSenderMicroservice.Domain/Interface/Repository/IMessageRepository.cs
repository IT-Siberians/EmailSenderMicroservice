using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    internal interface IMessageRepository : IBaseRepository<Message, Guid>
    {
    }
}
