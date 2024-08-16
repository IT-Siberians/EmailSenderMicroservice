using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.DataAccess.Interface
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository: IRepository<Message, Guid>
    {
    }
}
