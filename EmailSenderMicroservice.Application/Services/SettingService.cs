using AutoMapper;
using EmailSenderMicroservice.Application.Interface;
using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Application.Services
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public SettingService(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }
        public async Task<Guid> AddAsync(SettingAddModel entity)
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

            return settings.Select(z=> new SettingModel(
                z.Id,
                z.Connection.Address,
                z.Connection.Port,
                z.UseSSL,
                z.Login.Value,
                z.Password,
                z.CreateDate));

            //return settings.Select(_mapper.Map<SettingModel>);
        }

        public async Task<SettingModel?> GetAsync()
        {
            var setting = await _settingRepository.GetAsync(_cancellationTokenSource.Token);

            return setting is null ? null : new SettingModel(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreateDate);

            //(_mapper.Map<SettingModel>(setting));
        }

        public async Task<SettingModel?> GetByIdAsync(Guid id)
        {
            var setting = await _settingRepository.GetByIdAsync(id, _cancellationTokenSource.Token);


            return setting is null ? null : new SettingModel(
                setting.Id,
                setting.Connection.Address,
                setting.Connection.Port,
                setting.UseSSL,
                setting.Login.Value,
                setting.Password,
                setting.CreateDate);

                //(_mapper.Map<SettingModel>(setting));
        }
    }
}
