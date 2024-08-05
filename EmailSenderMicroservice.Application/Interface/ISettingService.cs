using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Interface.Service;

namespace EmailSenderMicroservice.Application.Interface
{
    /// <summary>
    /// Описания методов для сервиса Настроек.
    /// </summary>
    public interface ISettingService : IBaseService<SettingModel, SettingAddModel, Guid>
    {
        /// <summary>
        /// Получение текущих настроек сервиса отправки сообщений
        /// </summary>
        /// <returns>Сущность с текущими настройками</returns>
        Task<SettingModel?> GetAsync();
    }
}
