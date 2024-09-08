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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Добавляет новое сообщение.
        /// </summary>
        /// <param name="entity">Модель сообщения для добавления.</param>
        /// <returns>Идентификатор добавленного сообщения.</returns>
        public async Task<Guid> AddAsync(AddMessageModel entity)
        {
            var message = new Message(
                new Email(entity.Email),
                entity.MessageType,
                entity.MessageText,
                false,
                DateTime.UtcNow);

            return await messageRepository.AddAsync(message, _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Получает все сообщения.
        /// </summary>
        /// <returns>Список моделей сообщений.</returns>
        public async Task<IEnumerable<MessageModel>> GetAllAsync()
        {
            var messages = await messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return messages.Select(mapper.Map<MessageModel>);
        }

        /// <summary>
        /// Получает сообщение по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сообщения.</param>
        /// <returns>Модель сообщения или <c>null</c>, если сообщение не найдено.</returns>
        public async Task<MessageModel?> GetByIdAsync(Guid id)
        {
            var message = await messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            return mapper.Map<MessageModel>(message);
        }
    }
}
