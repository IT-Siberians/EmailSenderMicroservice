namespace NotificationMicroservice.Domain.Exception.Setting
{
    internal class SettingGuidEmptyException : System.Exception
    {
        public SettingGuidEmptyException()
        {
        }

        public SettingGuidEmptyException(string? name) 
            : base($"Identifier '{name}' cannot be empty")
        {
        }

        public SettingGuidEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}