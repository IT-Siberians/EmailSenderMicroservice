using NotificationMicroservice.Domain.Models;

namespace NotificationMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для сервиса Настроек.
    /// </summary>
    internal interface ISettingService : IBaseService<Setting, Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Сущность с текущими настройками</returns>
        Task<Setting> GetAsync();
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<Guid> UpdateAsync(Setting entity);
    }
}
