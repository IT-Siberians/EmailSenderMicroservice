namespace EmailSenderMicroservice.Domain.Exception.Message
{ 
    internal class MessageTextNullOrEmptyException : ArgumentException
    {
        public MessageTextNullOrEmptyException()
        {
        }

        public MessageTextNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageTextNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}