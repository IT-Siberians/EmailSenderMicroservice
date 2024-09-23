using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.ValueObject
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">Информационное сообщение</param>
    internal class EmailInvalidException(string value) : FormatException(string.Format(StringValues.ERROR_EMAIL, value));
}