using EmailSenderMicroservice.DataAccess.Entities;
using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Interface.Service;
using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository<MessageEntity, Guid> _messageRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository<MessageEntity, Guid> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Guid> AddAsync(Message entity)
        {
            var messageEntity = new MessageEntity()
            {
                Id = entity.Id,
                Email = entity.Email.Value,
                Type = entity.MessageType,
                Text = entity.MessageText,
                Status = entity.Status,
                CreateDate = entity.CreateDate
            };

            return await _messageRepository.AddAsync(messageEntity, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<Message>> GetAllAsync()
        {
            var entitiesDB = await _messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return entitiesDB
                    .Select(z => new Message(
                        z.Id,
                        z.Email,
                        z.Type,
                        z.Text,
                        z.Status,
                        z.CreateDate));
        }

        public async Task<Message>? GetByIdAsync(Guid id)
        {
            var entityDB = await _messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            if (entityDB == null)
            {
                throw new InvalidOperationException("FAAAAAAIIIIIIL");
            }

            return new Message(
                    entityDB.Id,
                    entityDB.Email,
                    entityDB.Type,
                    entityDB.Text,
                    entityDB.Status,
                    entityDB.CreateDate);
        }
    }
}
