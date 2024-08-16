namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение значения параметра порта сервера
    /// </summary>
    public class SettingServerPortException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingServerPortException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}