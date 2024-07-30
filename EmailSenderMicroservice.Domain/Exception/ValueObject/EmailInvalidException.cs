namespace EmailSenderMicroservice.Domain.Exception.VoalueObject
{
    /// <summary>
    /// Исключение проверки строки на соответсвуе Email
    /// </summary>
    internal class EmailInvalidException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public EmailInvalidException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public EmailInvalidException(string? message, string? value) 
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public EmailInvalidException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}