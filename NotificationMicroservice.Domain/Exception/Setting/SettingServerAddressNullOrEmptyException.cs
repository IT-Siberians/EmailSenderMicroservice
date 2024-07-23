namespace NotificationMicroservice.Domain.Exception.Setting
{
    internal class SettingServerAddressNullOrEmptyException : System.Exception
    {
        public SettingServerAddressNullOrEmptyException()
        {
        }

        public SettingServerAddressNullOrEmptyException(string? name) 
            : base($"Server address '{name}' cannot be empty.")
        {
        }

        public SettingServerAddressNullOrEmptyException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}