using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    public class SettingPasswordNullOrEmptyException(string value) : ArgumentNullException(value, StringValues.ERROR_SERVER_PASS);
}