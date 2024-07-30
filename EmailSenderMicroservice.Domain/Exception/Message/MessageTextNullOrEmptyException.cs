namespace EmailSenderMicroservice.Domain.Exception.Message
{ 
    public class MessageTextNullOrEmptyException : ArgumentException
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