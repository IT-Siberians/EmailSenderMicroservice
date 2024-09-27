using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Значение вызвавшее исключение</param>
    public class SettingServerPortException(string value) : ArgumentOutOfRangeException(value, StringValues.ERROR_SERVER_PORT);
}