using EmailSenderMicroservice.DataAccess.Repositories.Abstraction.Base;
using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.DataAccess.Repositories.Abstraction
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    public interface IMessageRepository : IRepository<Message, Guid>
    {
        /// <summary>
        /// Обновление сообщения
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<bool> UpdateAsync(Message entity, CancellationToken cancellationToken);
    }
}
