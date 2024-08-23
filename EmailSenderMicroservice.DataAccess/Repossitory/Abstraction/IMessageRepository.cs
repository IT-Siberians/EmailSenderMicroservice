using EmailSenderMicroservice.DataAccess.Repossitory.Abstraction.Base;
using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.DataAccess.Repossitory.Abstraction
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository : IRepository<Message, Guid>
    {
    }
}
