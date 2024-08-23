using EmailSenderMicroservice.Application.Model;
using EmailSenderMicroservice.Application.Services.Abstraction.Base;

namespace EmailSenderMicroservice.Application.Services.Abstraction
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    public interface IMessageService : IService<MessageModel, MessageAddModel, Guid>
    {

    }
}
