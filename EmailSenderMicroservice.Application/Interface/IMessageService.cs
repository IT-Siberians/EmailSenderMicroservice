using EmailSenderMicroservice.Application.Model;

namespace EmailSenderMicroservice.Application.Interface
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    public interface IMessageService : IService<MessageModel, MessageAddModel, Guid>
    {

    }
}
