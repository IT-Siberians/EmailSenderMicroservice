namespace NotificationMicroservice.Domain.Exception.Message
{
    internal class MessageTypeNullOrEmptyException : System.Exception
    {
        public MessageTypeNullOrEmptyException()
        {
        }

        public MessageTypeNullOrEmptyException(string? name) 
            : base($"The '{name}' cannot be empty")
        {
        }

        public MessageTypeNullOrEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}