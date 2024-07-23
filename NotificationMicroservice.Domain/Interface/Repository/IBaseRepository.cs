namespace NotificationMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для базового репозитория.
    /// </summary>
    internal interface IBaseRepository<TEntity, TKey>
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
        /// <returns>Идентификатор сущности</returns>
        Task<TKey> AddAsync(TEntity entity);
    }
}
