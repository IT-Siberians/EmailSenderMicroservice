namespace EmailSenderMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение пустого значения идентификатора
    /// </summary>
    public class MessageGuidEmptyException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public MessageGuidEmptyException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public MessageGuidEmptyException(string? message, ArgumentException? innerException)
            : base(message, innerException)
        {
        }
    }
}