namespace EmailSenderMicroservice.Domain.Exception.VoalueObject
{
    internal class EmailInvalidException : ArgumentException
    {
        public EmailInvalidException()
        {
        }

        public EmailInvalidException(string? message, string? value) 
            : base(message, value)
        {
        }

        public EmailInvalidException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}