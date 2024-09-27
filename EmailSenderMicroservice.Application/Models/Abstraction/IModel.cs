namespace EmailSenderMicroservice.Application.Models.Abstraction
{
    public interface IModel<TKey> where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; }
        DateTime CreationDate { get; }
    }
}
