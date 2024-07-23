namespace NotificationMicroservice.Domain.Exception.Setting
{
    internal class SettingPasswordNullOrEmptyException : System.Exception
    {
        public SettingPasswordNullOrEmptyException()
        {
        }

        public SettingPasswordNullOrEmptyException(string? name) 
            : base($"Password '{name}' cannot be empty")
        {
        }

        public SettingPasswordNullOrEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}