using EmailSenderMicroservice.Domain.Helpers;

namespace EmailSenderMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    public class MessageTextNullOrEmptyException(string value) : ArgumentNullException(value, StringValues.ERROR_TEXT);
}