namespace EmailSenderMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Настроек.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public interface ISettingRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    {
        /// <summary>
        /// Получение текущих настроек отправки сообщений
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Сущность с текущими настройки</returns>
        Task<TEntity>? GetAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Обновление настроек отправки сообщений
        /// </summary>
        /// <param name="entity"> Сущность для изменения. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Идентификатор обновленной сущности</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
