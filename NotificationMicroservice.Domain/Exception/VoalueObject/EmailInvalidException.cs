namespace NotificationMicroservice.Domain.Exception.VoalueObject
{
    [Serializable]
    internal class EmailInvalidException : System.Exception
    {
        public EmailInvalidException()
        {
        }

        public EmailInvalidException(string? name) : base($"Email in '{name}' is not valid")
        {
        }

        public EmailInvalidException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }
    }
}