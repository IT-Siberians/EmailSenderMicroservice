namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение пустого значения пароля
    /// </summary>
    public class SettingPasswordNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingPasswordNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}