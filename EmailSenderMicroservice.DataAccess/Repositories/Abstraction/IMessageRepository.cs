using EmailSenderMicroservice.DataAccess.Repositories.Abstraction.Base;
using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.DataAccess.Repositories.Abstraction
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository : IRepository<Message, Guid>
    {
    }
}
