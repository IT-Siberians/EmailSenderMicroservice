using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess.Repossitory
{
    public class SettingRepository : ISettingRepository
    {
        private readonly EmailSenderMicroserviceDbContext _context;

        public SettingRepository(EmailSenderMicroserviceDbContext context)
        {  
            _context = context; 
        }

        public async Task<Guid> AddAsync(Setting entity, CancellationToken cancellationToken)
        {
            await _context.Settings.AddAsync(entity);
            await _context.SaveChangesAsync();
            
            return entity.Id;
        }

        public async Task<IEnumerable<Setting>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Settings.AsNoTracking() : _context.Settings)
                .ToListAsync(cancellationToken);
        }

        public async Task<Setting?> GetAsync(CancellationToken cancellationToken)
        {
            return await _context.Settings
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Setting?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Settings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UpdateAsync(Setting entity, CancellationToken cancellationToken)
        {
            await _context.Settings
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                .SetProperty(a => a.Connection, a => entity.Connection)
                .SetProperty(a => a.UseSSL, a => entity.UseSSL)
                .SetProperty(a => a.Login, a => entity.Login)
                .SetProperty(a => a.Password, a => entity.Password)
                .SetProperty(a => a.Password, a => entity.Password)
                .SetProperty(a => a.CreateDate, a => entity.CreateDate)
                );

            return true;
        }
    }
}
