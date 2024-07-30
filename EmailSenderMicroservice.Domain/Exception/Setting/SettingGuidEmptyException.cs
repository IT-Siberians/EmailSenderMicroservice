﻿namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    public class SettingGuidEmptyException : ArgumentException
    {
        public SettingGuidEmptyException()
        {
        }

        public SettingGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingGuidEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}