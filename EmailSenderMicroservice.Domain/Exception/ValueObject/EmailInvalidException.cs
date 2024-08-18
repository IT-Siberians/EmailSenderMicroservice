namespace EmailSenderMicroservice.Domain.Exception.VoalueObject
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    /// <param name="value">значение параметра вызвашвего исключение</param>
    internal class EmailInvalidException(string message, string value) : ArgumentException(message, value)
    {

    }
}