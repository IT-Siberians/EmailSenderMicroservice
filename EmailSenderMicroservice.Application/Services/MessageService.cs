using AutoMapper;
using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.ValueObjects;

namespace EmailSenderMicroservice.Application.Services
{
    /// <summary>
    /// Служба для управления сообщениями.
    /// </summary>
    /// <param name="messageRepository">Репозиторий для работы с сообщениями.</param>
    /// <param name="mapper">Маппер для преобразования сущностей в модели и наоборот.</param>
    public class MessageService(IMessageRepository messageRepository, IMapper mapper) : IMessageService
    {
        /// <summary>
        /// Добавляет новое сообщение.
        /// </summary>
        /// <param name="entity">Модель сообщения для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор добавленного сообщения.</returns>
        public async Task<Guid> AddAsync(AddMessageModel entity, CancellationToken cancellationToken = default)
        {
            var message = new Message(
                new Email(entity.Email),
                entity.MessageType,
                entity.MessageText,
                false,
                DateTime.UtcNow);

            return await messageRepository.AddAsync(message, cancellationToken);
        }

        /// <summary>
        /// Получает все сообщения.
        /// </summary>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Список моделей сообщений.</returns>
        public async Task<IEnumerable<MessageModel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var messages = await messageRepository.GetAllAsync(cancellationToken, true);

            return messages.Select(mapper.Map<MessageModel>);
        }

        /// <summary>
        /// Получает сообщение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель сообщения или <c>null</c>, если сообщение не найдено.</returns>
        public async Task<MessageModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var message = await messageRepository.GetByIdAsync(id, cancellationToken);

            return mapper.Map<MessageModel>(message);
        }

        /// <summary>
        /// Обновляет статус отправки сообщения.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сообщения.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>True, если статус отправки успешно обновлен, иначе False.</returns>
        /// <remarks>Обновляет статус отправки сообщения с указанным идентификатором.</remarks>
        public async Task<bool> SetSendedStatusAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var message = await messageRepository.GetByIdAsync(id, cancellationToken);

            if (message == null)
            {
                return false;
            }

            message.MarkAsSended();

            return await messageRepository.UpdateAsync(message, cancellationToken);
        }
    }
}
