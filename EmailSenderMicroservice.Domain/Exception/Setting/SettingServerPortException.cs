using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Информационное сообщение</param>
    /// 
    public class SettingServerPortException(string value, string message) : ArgumentOutOfRangeException(value, message)
    {

    }
}