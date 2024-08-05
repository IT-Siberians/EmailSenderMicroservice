using AutoMapper;
using EmailSenderMicroservice.Application.Interface;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(MessageAddModel entity)
        {
            var result = new Message(
                Guid.NewGuid(), 
                new Email(entity.Email), 
                entity.MessageType, 
                entity.MessageText, 
                false, 
                DateTime.UtcNow);

            return await _messageRepository.AddAsync(result, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<MessageModel>> GetAllAsync()
        {
            var messages = await _messageRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return messages.Select(z=> new MessageModel(
                z.Id,
                z.ToEmail.Value,
                z.MessageType,
                z.MessageText,
                z.Status,
                z.CreateDate)); 
            
            //return messages.Select(_mapper.Map<MessageModel>)
        }

        public async Task<MessageModel?> GetByIdAsync(Guid id)
        {
            var message = await _messageRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            return message is null ? null : new MessageModel(
                message.Id,
                message.ToEmail.Value,
                message.MessageType,
                message.MessageText,
                message.Status,
                message.CreateDate);

                //_mapper.Map<MessageModel>(message);
        }
    }
}
