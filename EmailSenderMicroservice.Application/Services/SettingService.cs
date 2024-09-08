using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.ValueObjects;

namespace EmailSenderMicroservice.Application.Services
{
    /// <summary>
    /// Служба для управления настройками приложения.
    /// </summary>
    /// <param name="settingRepository">Репозиторий для работы с настройками.</param>
    public class SettingService(ISettingRepository settingRepository) : ISettingService
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Добавляет новую настройку в репозиторий.
        /// </summary>
        /// <param name="entity">Модель настройки для добавления.</param>
        /// <returns>Идентификатор добавленной настройки.</returns>
        public async Task<Guid> AddAsync(AddSettingModel entity)
        {
            var setting = new Setting(
                new Connection(entity.ServerAddress, entity.ServerPort),
                entity.UseSSL,
                new Email(entity.Login),
                entity.Password,
                DateTime.UtcNow);

            return await settingRepository.AddAsync(setting, _cancellationTokenSource.Token);
        }

        /// <summary>
        /// Получает все настройки из репозитория.
        /// </summary>
        /// <returns>Список моделей настроек.</returns>
        public async Task<IEnumerable<SettingModel>> GetAllAsync()
        {
            var settings = await settingRepository.GetAllAsync(_cancellationTokenSource.Token, true);

            return settings.Select(z => new SettingModel(
                z.Id,
                z.Connection.Address,
                z.Connection.Port,
                z.UseSSL,
                z.Login.Value,
                z.Password,
                z.CreationDate));
        }

        /// <summary>
        /// Получает текущую настройку из репозитория.
        /// </summary>
        /// <returns>Модель текущей настройки или <c>null</c>, если настройка не найдена.</returns>
        public async Task<SettingModel?> GetCurrentAsync()
        {
            var setting = await settingRepository.GetCurrentAsync(_cancellationTokenSource.Token);

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

        /// <summary>
        /// Получает настройку по идентификатору из репозитория.
        /// </summary>
        /// <param name="id">Идентификатор настройки.</param>
        /// <returns>Модель настройки или <c>null</c>, если настройка не найдена.</returns>
        public async Task<SettingModel?> GetByIdAsync(Guid id)
        {
            var setting = await settingRepository.GetByIdAsync(id, _cancellationTokenSource.Token);

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
