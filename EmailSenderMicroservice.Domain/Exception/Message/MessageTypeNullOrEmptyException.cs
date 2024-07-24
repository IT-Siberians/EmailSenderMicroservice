namespace EmailSenderMicroservice.Domain.Exception.Message
{
    internal class MessageTypeNullOrEmptyException : ArgumentException
    {
        public MessageTypeNullOrEmptyException()
        {
        }

        public MessageTypeNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTypeNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}