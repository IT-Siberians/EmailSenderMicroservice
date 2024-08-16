namespace EmailSenderMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение пустого значения типа сообщения
    /// </summary>
    public class MessageTypeNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageTypeNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}