namespace EmailSenderMicroservice.Application.Models.Abstraction
{
    /// <summary>
    /// Маркерный интерфейс для моделей
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IModel<TKey> where TKey : struct, IEquatable<TKey>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        TKey Id { get; }

        /// <summary>
        /// Время создания
        /// </summary>
        DateTime CreationDate { get; }
    }
}
