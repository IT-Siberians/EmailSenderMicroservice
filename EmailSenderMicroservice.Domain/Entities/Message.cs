using EmailSenderMicroservice.Domain.Entities.Base;
using EmailSenderMicroservice.Domain.Exception.Message;
using EmailSenderMicroservice.Domain.ValueObjects;

namespace EmailSenderMicroservice.Domain.Entities
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
        /// Тип сообщения
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
        public DateTime CreationDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
#pragma warning disable CS8618
        protected Message() { }
#pragma warning disable CS8618

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="email">адрес получателя сообщений</param>
        /// <param name="messageType">тип сообщений</param>
        /// <param name="messageText">текст сообщения</param>
        /// <param name="status">статус отправки</param>
        /// <param name="creationDate">дата и время отправления сообщения</param>
        /// <returns>Сущность</returns>
        /// <exception cref="MessageTypeNullOrEmptyException">Исключение пустого значения типа направляемого сообщения</exception>
        /// <exception cref="MessageTextNullOrEmptyException">Исключение пустого значения текста направляемого сообщения</exception>
        public Message(Email email, string messageType, string messageText, bool status, DateTime creationDate)
        {

            if (string.IsNullOrWhiteSpace(messageType))
            {
                throw new MessageTypeNullOrEmptyException(messageType);
            }

            if (string.IsNullOrWhiteSpace(messageText))
            {
                throw new MessageTextNullOrEmptyException(messageText);
            }

            Email = email;
            MessageType = messageType;
            MessageText = messageText;
            Status = status;
            CreationDate = creationDate;
        }

        /// <summary>
        /// Метод для изменения статуса доставки на отправлен.
        /// </summary>
        public void MarkAsSended()
        {
            Status = true;
        }
    }
}
