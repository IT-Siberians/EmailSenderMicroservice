using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для сервиса Настроек.
    /// </summary>
    public interface ISettingService : IBaseService<Setting, Guid>
    {
        /// <summary>
        /// Получение текущих настроек сервиса отправки сообщений
        /// </summary>
        /// <returns>Сущность с текущими настройками</returns>
        Task<Setting>? GetAsync();     
    }
}
