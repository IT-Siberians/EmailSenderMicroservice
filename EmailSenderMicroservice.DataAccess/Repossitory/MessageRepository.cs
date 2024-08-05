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
        
        public async Task<IEnumerable<Message>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking)
        {
            return await(asNoTracking ? _context.Messages.AsNoTracking() : _context.Messages)
                .ToListAsync(cancellationToken);
        }

        public async Task<Message?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Messages
                .Where(x => x.Id == id)                
                .FirstOrDefaultAsync(cancellationToken);            
        }

        public async Task<Guid> AddAsync(Message entity, CancellationToken cancellationToken)
        {

            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
    }
}
