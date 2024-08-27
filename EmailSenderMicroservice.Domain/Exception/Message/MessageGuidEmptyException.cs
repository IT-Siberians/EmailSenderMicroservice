namespace EmailSenderMicroservice.Domain.Exception.Message
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    public class MessageGuidEmptyException(string message, string value) : ArgumentNullException(value, message)
    {

    }
}