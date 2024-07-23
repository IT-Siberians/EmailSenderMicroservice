using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Настроек.
    /// </summary>
    internal interface ISettingRepository : IBaseRepository<Setting, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Сущность с текущими настройки</returns>
        Task<Setting>? GetAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Идентификатор сущности</param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<Guid> UpdateAsync(Guid key);
    }
}
