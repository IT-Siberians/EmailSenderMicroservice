﻿using System.Xml.Linq;

namespace NotificationMicroservice.Domain.Exception.Message
{
    [Serializable]
    internal class MessageTextNullOrEmptyException : System.Exception
    {
        public MessageTextNullOrEmptyException()
        {
        }

        public MessageTextNullOrEmptyException(string? name) 
            : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTextNullOrEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}