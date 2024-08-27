﻿namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    /// <summary>
    /// Конструктор с информационным сообщением и значением параметра
    /// </summary>
    /// <param name="message">Информационное сообщение</param>
    public class SettingServerAddressLengthException(string message) : FormatException(message)
    {

    }
}