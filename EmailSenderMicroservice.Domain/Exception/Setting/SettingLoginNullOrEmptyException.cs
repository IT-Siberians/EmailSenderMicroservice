namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    public class SettingLoginNullOrEmptyException(string message, string value) : ArgumentNullException(value, message)
    {

    }
}