using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        public async Task<Guid> AddAsync(AddSettingModel entity)
        {
            var setting = new Setting(
                Guid.NewGuid(),
                new Connection(entity.ServerAddress, entity.ServerPort),
                entity.UseSSL,
                new Email(entity.Login),
                entity.Password,
                DateTime.UtcNow);

            return await _settingRepository.AddAsync(setting, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<SettingModel>> GetAllAsync()
        {
            var settings = await _settingRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return settings.Select(z => new SettingModel(
                z.Id,
                z.Connection.Address,
                z.Connection.Port,
                z.UseSSL,
                z.Login.Value,
                z.Password,
                z.CreationDate));
        }

        public async Task<SettingModel?> GetCurrentAsync()
        {
            var setting = await _settingRepository.GetCurrentAsync(_cancellationTokenSource.Token);

            return setting is null ? null :
            new SettingModel(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreationDate);
        }

        public async Task<SettingModel?> GetByIdAsync(Guid id)
        {
            var setting = await _settingRepository.GetByIdAsync(id, _cancellationTokenSource.Token);


            return setting is null ? null :
                new SettingModel(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreationDate);
        }
    }
}
