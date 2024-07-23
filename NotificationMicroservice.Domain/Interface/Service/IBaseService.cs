namespace NotificationMicroservice.Domain.Interface.Service
{
    /// <summary>
    /// Описания методов для базового сервиса.
    /// </summary>
    internal interface IBaseService<TEntity, TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Коллекция сущностей</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">Идентификатор сущности</param>
        /// <returns>Сущность</returns>
        Task<TEntity> GetByIdAsync(TKey key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Идентификатор добавленной сущности</returns>
        Task<TKey> AddAsync(TEntity entity);        
        
    }
}
