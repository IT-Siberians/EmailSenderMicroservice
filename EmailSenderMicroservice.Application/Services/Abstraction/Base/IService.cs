namespace EmailSenderMicroservice.Application.Services.Abstraction.Base
{
    /// <summary>
    /// Описания методов для базового сервиса.
    /// </summary>
    /// <typeparam name="TEntity">Основной класс сущности</typeparam>
    /// <typeparam name="TEntityAdd">Класс сущности для добавления</typeparam>
    /// <typeparam name="TKey">Идентификатор</typeparam>
    public interface IService<TEntity, TEntityAdd, TKey> 
        where TEntity : class 
        where TEntityAdd : class 
        where TKey : struct
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
        Task<TEntity?> GetByIdAsync(TKey key);

        /// <summary>
        /// Добавление сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Идентификатор добавленной сущности</returns>
        Task<TKey> AddAsync(TEntityAdd entity);

    }
}
