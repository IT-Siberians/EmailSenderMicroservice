namespace EmailSenderMicroservice.Domain.Interface.Model
{
    /// <summary>
    /// Описание базовой Entity 
    /// </summary>
    /// <typeparam name="TKey"> Тип первичного ключа. </typeparam>
    public interface IEntity<Tkey> where Tkey : struct
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        Tkey Id { get; }

        /// <summary>
        /// Дата и время создания
        /// </summary>
        DateTime CreateDate { get; }
    }
}
