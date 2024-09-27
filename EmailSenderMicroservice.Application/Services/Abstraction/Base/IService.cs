using EmailSenderMicroservice.Application.Models.Abstraction;

namespace EmailSenderMicroservice.Application.Services.Abstraction.Base
{
    /// <summary>
    /// Предоставляет методы для базового сервиса.
    /// </summary>
    /// <typeparam name="TEntity">Основной класс сущности.</typeparam>
    /// <typeparam name="TEntityAdd">Класс сущности, используемый для добавления.</typeparam>
    /// <typeparam name="TKey">Тип идентификатора.</typeparam>
    public interface IService<TEntity, TEntityAdd, TKey>
        where TEntity : class, IModel<TKey>
        where TEntityAdd : class, IAddModel
        where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Получает все сущности.
        /// </summary>
        /// <returns>Коллекцию сущностей.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получает конкретную сущность по ее идентификатору.
        /// </summary>
        /// <param name="key">Идентификатор сущности.</param>
        /// <returns>Сущность.</returns>
        Task<TEntity?> GetByIdAsync(TKey key, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет новую сущность.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        /// <returns>Идентификатор добавленной сущности.</returns>
        Task<TKey> AddAsync(TEntityAdd entity, CancellationToken cancellationToken);
    }
}
