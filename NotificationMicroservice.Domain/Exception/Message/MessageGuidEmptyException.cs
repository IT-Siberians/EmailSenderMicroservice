namespace NotificationMicroservice.Domain.Exception.Message
{
    [Serializable]
    internal class MessageGuidEmptyException : System.Exception
    {
        public MessageGuidEmptyException()
        {
        }

        public MessageGuidEmptyException(string? name) 
            : base($"Identifier '{name}' cannot be empty")
        {
        }

        public MessageGuidEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}