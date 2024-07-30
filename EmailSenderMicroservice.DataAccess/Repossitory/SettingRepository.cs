using EmailSenderMicroservice.DataAccess.Entities;
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
            var settingEntity = new SettingEntity()
            {
                Id = entity.Id,
                ServerAddress = entity.ServerAddress,
                ServerPort = entity.ServerPort,
                UseSSL = entity.UseSSL,
                Login = entity.Login.Value,
                Password = entity.Password,
                CreateDate = entity.CreateDate,
            };

            await _context.Settings.AddAsync(settingEntity);
            await _context.SaveChangesAsync();
            
            return entity.Id;
        }

        public async Task<IEnumerable<Setting>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false)
        {
            return await (asNoTracking ? _context.Settings.AsNoTracking() : _context.Settings)
                .Select(z=> new Setting(
                    z.Id,
                    z.ServerAddress, 
                    z.ServerPort, 
                    z.UseSSL,
                    z.Login,
                    z.Password,
                    z.CreateDate))
                .ToListAsync(cancellationToken);
        }

        public async Task<Setting>? GetAsync(CancellationToken cancellationToken)
        {
            return await _context.Settings
                .Select(z => new Setting(
                    z.Id,
                    z.ServerAddress,
                    z.ServerPort,
                    z.UseSSL,
                    z.Login,
                    z.Password,
                    z.CreateDate))
                .FirstAsync(cancellationToken);
        }

        public async Task<Setting>? GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var settingEntity = await _context.Settings
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (settingEntity == null)
            {
                throw new InvalidOperationException("FAAAAAAIIIIIIL");
            }

            return new Setting(
                    settingEntity.Id,
                    settingEntity.ServerAddress,
                    settingEntity.ServerPort,
                    settingEntity.UseSSL,
                    settingEntity.Login,
                    settingEntity.Password,
                    settingEntity.CreateDate);
        }

        public async Task<bool> UpdateAsync(Setting entity, CancellationToken cancellationToken)
        {
            await _context.Settings
                .Where(x => x.Id == entity.Id)
                .ExecuteUpdateAsync(z => z
                .SetProperty(a => a.ServerAddress, a => entity.ServerAddress)
                .SetProperty(a => a.ServerPort, a => entity.ServerPort)
                .SetProperty(a => a.UseSSL, a => entity.UseSSL)
                .SetProperty(a => a.Login, a => entity.Login.Value)
                .SetProperty(a => a.Password, a => entity.Password)
                .SetProperty(a => a.Password, a => entity.Password)
                .SetProperty(a => a.CreateDate, a => entity.CreateDate)
                );

            return true;
        }
    }
}
