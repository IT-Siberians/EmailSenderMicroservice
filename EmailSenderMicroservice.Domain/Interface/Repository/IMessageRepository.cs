namespace EmailSenderMicroservice.Domain.Interface.Repository
{
    /// <summary>
    /// Описания методов для репозитория Сообщений.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public interface IMessageRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
    {
    }
}
