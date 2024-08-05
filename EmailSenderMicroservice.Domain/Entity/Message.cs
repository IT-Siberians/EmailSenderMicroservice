using EmailSenderMicroservice.Domain.Interface.Model;
using EmailSenderMicroservice.Domain.Exception.Message;
using EmailSenderMicroservice.Domain.ValueObject;
using EmailSenderMicroservice.Domain.Resources;

namespace EmailSenderMicroservice.Domain.Models
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : IEntity<Guid>
    {        
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Email получателя
        /// </summary>
        public Email Email { get; }
        
        /// <summary>
        /// Название шаблона сообщений
        /// </summary>
        public string MessageType { get; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get; }

        /// <summary>
        /// Статус отправки сообщения
        /// </summary>
        public bool Status { get; private set; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="email">адрес получателя сообщений</param>
        /// <param name="messageType">тип сообщений</param>
        /// <param name="messageText">текст сообщения</param>
        /// <param name="status">статус отправки</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Сущность</returns>
        /// <exception cref="MessageGuidEmptyException">Исключение пустого значения идентификатора</exception>
        /// <exception cref="MessageTypeNullOrEmptyException">Исключение пустого значения типа направляемого сообщения</exception>
        /// <exception cref="MessageTextNullOrEmptyException">Исключение пустого значения текста направляемого сообщения</exception>
        public Message(Guid id, Email email, string messageType, string messageText, bool status, DateTime createDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageGuidEmptyException(StringValue.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(messageType))
            {
                throw new MessageTypeNullOrEmptyException(StringValue.ERROR_TYPE, messageType);
            }

            if (string.IsNullOrEmpty(messageText))
            {
                throw new MessageTextNullOrEmptyException(StringValue.ERROR_TEXT, messageText);
            }

            Id = id;
            Email = email;
            MessageType = messageType;
            MessageText = messageText;
            Status = status;
            CreateDate = createDate;
        }

        public void Sended ()
        {
            Status = true;
        }
        
    }
}
