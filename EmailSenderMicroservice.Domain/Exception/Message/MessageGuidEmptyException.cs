namespace EmailSenderMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Исключение пустого значения идентификатора
    /// </summary>
    public class MessageGuidEmptyException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public MessageGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}