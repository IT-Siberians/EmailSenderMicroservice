using EmailSenderMicroservice.Domain.Models;

namespace EmailSenderMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Настроек.
    /// </summary>
    public interface ISettingRepository : IBaseRepository<Setting, Guid>
    {
        /// <summary>
        /// Получение текущих настроек отправки сообщений
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Сущность с текущими настройки</returns>
        Task<Setting>? GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Обновление настроек отправки сообщений
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<bool> UpdateAsync(Setting entity, CancellationToken cancellationToken);
    }
}
