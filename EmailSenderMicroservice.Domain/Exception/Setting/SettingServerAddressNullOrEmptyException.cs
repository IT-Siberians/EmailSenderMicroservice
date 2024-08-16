namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение пустого значения адреса сервера
    /// </summary>
    public class SettingServerAddressNullOrEmptyException : ArgumentNullException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingServerAddressNullOrEmptyException(string? message, string? value)
            : base(value, message)
        {
        }
    }
}