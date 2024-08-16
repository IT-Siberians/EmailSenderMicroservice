namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Исключение нарушения ограничений длинны значения адреса сервера
    /// </summary>
    public class SettingServerAddressLengthException : ArgumentException
    {
        /// <summary>
        /// Конструктор с информационным сообщением и значением параметра
        /// </summary>
        /// <param name="message">Информационное сообщение</param>
        /// <param name="value">значение параметра вызвашвего исключение</param>
        public SettingServerAddressLengthException(string? message, string? value)
            : base(message, value)
        {
        }
    }
}