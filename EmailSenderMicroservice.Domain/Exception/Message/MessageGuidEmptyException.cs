namespace EmailSenderMicroservice.Domain.Exception.Message
{
    public class MessageGuidEmptyException : ArgumentException
    {
        public MessageGuidEmptyException()
        {
        }

        public MessageGuidEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public MessageGuidEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}