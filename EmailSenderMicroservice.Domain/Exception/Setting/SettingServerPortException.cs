namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение значения параметра порта сервера
    /// </summary>
    public class SettingServerPortException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public SettingServerPortException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingServerPortException(string? message, string? value)
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public SettingServerPortException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}