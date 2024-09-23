using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="length">Информационное сообщение</param>
    /// <param name="value">Значение вызвавшее исключение</param>
    public class SettingServerAddressLengthException(int length, string value) : FormatException(string.Format(StringValues.ERROR_SERVER_ADDRESS_LENGTH, length, value));
}