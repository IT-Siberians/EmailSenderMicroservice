namespace NotificationMicroservice.Domain.Exception.Setting
{
    internal class SettingServerPortException : System.Exception
    {
        public SettingServerPortException()
        {
        }

        public SettingServerPortException(string? name) 
            : base($"Specified port '{name}' cannot be negative or not a three-digit number")
        {
        }

        public SettingServerPortException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}