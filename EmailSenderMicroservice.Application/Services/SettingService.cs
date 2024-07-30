using EmailSenderMicroservice.Domain.Interface.Repository;
using EmailSenderMicroservice.Domain.Interface.Service;
using EmailSenderMicroservice.Domain.Models;

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
        public async Task<Guid> AddAsync(Setting entity)
        {
            return await _settingRepository.AddAsync(entity, _cancellationTokenSource.Token);
        }

        public async Task<IEnumerable<Setting>> GetAllAsync()
        {
            return await _settingRepository.GetAllAsync(_cancellationTokenSource.Token, true);
        }

        public async Task<Setting>? GetAsync()
        {
            return await _settingRepository.GetAsync(_cancellationTokenSource.Token);
        }

        public async Task<Setting>? GetByIdAsync(Guid id)
        {
            return await _settingRepository.GetByIdAsync(id, _cancellationTokenSource.Token);
        }
    }
}
