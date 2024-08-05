using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Domain.Interface.Service;

namespace EmailSenderMicroservice.Application.Interface
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    public interface IMessageService : IBaseService<MessageModel, MessageAddModel, Guid>
    {

    }
}
