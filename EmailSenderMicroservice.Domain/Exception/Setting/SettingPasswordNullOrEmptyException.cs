﻿namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    internal class SettingPasswordNullOrEmptyException : ArgumentException
    {
        public SettingPasswordNullOrEmptyException()
        {
        }

        public SettingPasswordNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingPasswordNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}