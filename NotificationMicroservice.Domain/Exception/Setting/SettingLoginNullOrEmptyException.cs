namespace NotificationMicroservice.Domain.Exception.Setting
{
    internal class SettingLoginNullOrEmptyException : System.Exception
    {
        public SettingLoginNullOrEmptyException()
        {
        }

        public SettingLoginNullOrEmptyException(string? name) 
            : base($"Login '{name}' cannot be empty or does not meet the requirements")
        {
        }

        public SettingLoginNullOrEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}