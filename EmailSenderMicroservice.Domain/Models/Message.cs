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
        
        private Guid _id;
        private Email _email;
        private string _messageType;
        private string _messageText;
        private bool _status;
        private DateTime _createDate;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

        /// <summary>
        /// Email получателя
        /// </summary>
        public Email Email { get => _email; }
        
        /// <summary>
        /// Название шаблона сообщений
        /// </summary>
        public string MessageType { get => _messageType; }
        
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string MessageText { get => _messageText; }

        /// <summary>
        /// Статус отправки сообщения
        /// </summary>
        public bool Status { get => _status; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

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
        public Message(Guid id, string email, string messageType, string messageText, bool status, DateTime createDate)
        {

            if (id == Guid.Empty)
            {
                throw new MessageGuidEmptyException(StringResources.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(messageType))
            {
                throw new MessageTypeNullOrEmptyException(StringResources.ERROR_TYPE, messageType);
            }

            if (string.IsNullOrEmpty(messageText))
            {
                throw new MessageTextNullOrEmptyException(StringResources.ERROR_TEXT, messageText);
            }

            _id = id;
            _email = new Email(email);
            _messageType = messageType;
            _messageText = messageText;
            _status = status;
            _createDate = createDate;
        }
        
    }
}
