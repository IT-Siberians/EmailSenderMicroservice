using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository: IBaseRepository<Message, Guid>
    {
    }
}
