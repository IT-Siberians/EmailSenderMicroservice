using EmailSenderMicroservice.DataAccess.Repositories.Abstraction.Base;
using EmailSenderMicroservice.Domain.Entities;

namespace EmailSenderMicroservice.DataAccess.Repositories.Abstraction
{
    /// <summary>
    /// Описания методов для репозитория Настроек.
    /// </summary>
    public interface ISettingRepository : IRepository<Setting, Guid>
    {
        /// <summary>
        /// Получение текущих настроек отправки сообщений
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Сущность с текущими настройки</returns>
        Task<Setting?> GetCurrentAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Обновление настроек отправки сообщений
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<bool> UpdateAsync(Setting entity, CancellationToken cancellationToken);
    }
}
