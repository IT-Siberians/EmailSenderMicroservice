using EmailSenderMicroservice.Application.Models.Message;
using EmailSenderMicroservice.Application.Services.Abstraction.Base;

namespace EmailSenderMicroservice.Application.Services.Abstraction
{
    /// <summary>
    /// Описания методов для сервиса Сообщений.
    /// </summary>
    public interface IMessageService : IService<MessageModel, AddMessageModel, Guid>
    {

    }
}
