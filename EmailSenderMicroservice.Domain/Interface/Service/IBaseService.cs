namespace EmailSenderMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для базового сервиса.
    /// </summary>
    public interface IBaseService<TEntity, TKey>
    {
        /// <summary>
        /// Получение всех сущностей
        /// </summary>
        /// <returns>Коллекция сущностей</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Получение конкретной сущности по идентификатору
        /// </summary>
        /// <param name="key">Идентификатор сущности</param>
        /// <returns>Сущность</returns>
        Task<TEntity>? GetByIdAsync(TKey key);

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Идентификатор добавленной сущности</returns>
        Task<TKey> AddAsync(TEntity entity);        
        
    }
}
