using EmailSenderMicroservice.DataAccess.Entities;
using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess.Repossitory
{
    public class MessageRepository : IMessageRepository
    {
        private readonly EmailSenderMicroserviceDbContext _context;

        public MessageRepository(EmailSenderMicroserviceDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken)
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
            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking)
        {
            return await(asNoTracking ? _context.Messages.AsNoTracking() : _context.Messages)
                .Select(z => new Message(
                    z.Id,
                    z.Email,
                    z.Type,
                    z.Text,
                    z.Status,
                    z.CreateDate))
                .ToListAsync(cancellationToken);
        }

        public async Task<Message>? GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var messageEntity = await _context.Messages
                .Where(x => x.Id == id)                
                .FirstOrDefaultAsync(cancellationToken);
           
            if (messageEntity == null)
            {
                throw new InvalidOperationException("FAAAAAAIIIIIIL");
            }

            return new Message(
                    messageEntity.Id,
                    messageEntity.Email,
                    messageEntity.Type,
                    messageEntity.Text,
                    messageEntity.Status,
                    messageEntity.CreateDate);
        }
    }
}
