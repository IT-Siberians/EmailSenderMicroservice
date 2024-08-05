namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение пустого значения логина
    /// </summary>
    public class SettingLoginNullOrEmptyException : ArgumentException
    {
        /// <summary>
        /// Основной конструктор
        /// </summary>
        public SettingLoginNullOrEmptyException()
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingLoginNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        /// <summary>
        /// Конструктор с информационным сообщением и исключением 
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="innerException">Внутренне исключение</param>
        public SettingLoginNullOrEmptyException(string? message, ArgumentException? innerException)
            : base(message, innerException)
        {
        }
    }
}