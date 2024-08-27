using EmailSenderMicroservice.Domain.Entities.Base;

namespace EmailSenderMicroservice.DataAccess.Repositories.Abstraction.Base
{
    /// <summary>
    /// Описания методов для базового репозитория.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public interface IRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey> 
        where TKey : struct
    {
        /// <summary>
        /// Получить сущность коллекцию сущностей.
        /// </summary>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <param name="asNoTracking"> Вызвать с AsNoTracking. </param>
        /// <returns> Коллекция сущностей. </returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken, bool asNoTracking = false);

        /// <summary>
        /// Получить сущность.
        /// </summary>
        /// <param name="id"> Идентификатор сущности. </param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns> Cущность. </returns>
        Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавление сущьности
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="cancellationToken"> Токен отмены. </param>
        /// <returns>Идентификатор сущности</returns>
        Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
