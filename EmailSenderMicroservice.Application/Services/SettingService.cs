using EmailSenderMicroservice.DataAccess.Entities;
using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Interface.Service;
using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository<SettingEntity, Guid> _settingRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public SettingService(ISettingRepository<SettingEntity, Guid> settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<Guid> AddAsync(Setting entity)
        {
            var settingEntity = new SettingEntity()
            {
                Id = entity.Id,
                ServerAddress = entity.Connection.Address,
                ServerPort = entity.Connection.Port,
                UseSSL = entity.UseSSL,
                Login = entity.Login.Value,
                Password = entity.Password,
                CreateDate = entity.CreateDate,
            };

            return await _settingRepository.AddAsync(settingEntity, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            var entitiesDB = await _settingRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return entitiesDB
                    .Select(z => new Setting(
                        z.Id,
                        new Connection(z.ServerAddress,z.ServerPort),
                        z.UseSSL,
                        new Email(z.Login),
                        z.Password,
                        z.CreateDate));
        }

        public async Task<Setting>? GetAsync()
        {
            var entityDb = await _settingRepository.GetAsync(_cancellationTokenSource.Token);

            if (entityDb == null)
            {
                throw new InvalidOperationException("FAAAAAAIIIIIIL");
            }

            return new Setting(
                    entityDb.Id,
                    new Connection(entityDb.ServerAddress, entityDb.ServerPort),
                    entityDb.UseSSL,
                    new Email(entityDb.Login),
                    entityDb.Password,
                    entityDb.CreateDate);
        }

        public async Task<Setting>? GetByIdAsync(Guid id)
        {
            var entityDb = await _settingRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

            if (entityDb == null)
            {
                throw new InvalidOperationException("FAAAAAAIIIIIIL");
            }

            return new Setting(
                    entityDb.Id,
                    new Connection(entityDb.ServerAddress, entityDb.ServerPort),
                    entityDb.UseSSL,
                    new Email(entityDb.Login),
                    entityDb.Password,
                    entityDb.CreateDate);
        }
    }
}
