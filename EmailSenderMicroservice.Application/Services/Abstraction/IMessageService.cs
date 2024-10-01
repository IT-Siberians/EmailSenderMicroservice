using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services.Abstraction.Base;

namespace EmailSenderMicroservice.Application.Services.Abstraction
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    public interface IMessageService : IService<MessageModel, AddMessageModel, Guid>
    {
        /// <summary>
        /// Обновление статуса отправки сообщения
        /// </summary>
        /// <returns>Сущность с текущими настройками</returns>
        /// <param name="id">Уникальный идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        Task<bool> SetSendedStatusAsync(Guid id, CancellationToken cancellationToken);
    }
}
