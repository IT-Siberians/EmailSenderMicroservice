namespace EmailSenderMicroservice.Domain.Exception.ValueObject
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    internal class EmailInvalidException(string message) : FormatException(message)
    {

    }
}