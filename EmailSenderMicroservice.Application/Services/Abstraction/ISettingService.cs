using EmailSenderMicroservice.Application.Models.Setting;
using EmailSenderMicroservice.Application.Services.Abstraction.Base;

namespace EmailSenderMicroservice.Application.Services.Abstraction
{
    /// <summary>
    /// Описания методов для сервиса Настроек.
    /// </summary>
    public interface ISettingService : IService<SettingModel, AddSettingModel, Guid>
    {
        /// <summary>
        /// Получение текущих настроек сервиса отправки сообщений
        /// </summary>
        /// <returns>Сущность с текущими настройками</returns>
        Task<SettingModel?> GetCurrentAsync(CancellationToken cancellationToken);
    }
}
