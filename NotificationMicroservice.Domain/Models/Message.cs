using EmailSenderMicroservice.Domain.Interface.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.Domain.Models
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Message : IEntity<Guid>
    {
        
        private Guid _id;
        private string _email;
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
        public string Email { get => _email; }
        
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

        public Message() { }

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
            _id = id;
            _email = email;
            _messageType = messageType;
            _messageText = messageText;
            _status = status;
            _createDate = createDate;
        }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="email">адрес получателя сообщений</param>
        /// <param name="messageType">тип сообщений</param>
        /// <param name="messageText">текст сообщения</param>
        /// <param name="status">статус отправки</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Кортеж (Сущностьб Ошибки)</returns>
        public (Message Message, string Error) Create(Guid id, string email, string messageType, string messageText, bool status, DateTime createDate)
        {
            var errorSb = new StringBuilder();

            if (id == Guid.Empty)
            {
                errorSb.AppendLine($"Identifier {id} cannot be empty");
            }

            if (string.IsNullOrEmpty(messageType))
            {
                errorSb.AppendLine($"MessageType {messageType} cannot be empty");
            }            

            if (string.IsNullOrEmpty(messageText))
            {
                errorSb.AppendLine($"MessageText {messageText} cannot be empty");
            }

            if (string.IsNullOrEmpty(email) || IsValidEmail(email))
            {
                errorSb.AppendLine($"Email {email} cannot be empty or does not meet the requirements");
            }


            return (new Message(id, email, messageType, messageText, status, createDate), errorSb.ToString());
        }
        private bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
