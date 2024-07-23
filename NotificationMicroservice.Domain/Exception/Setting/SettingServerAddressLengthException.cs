namespace NotificationMicroservice.Domain.Exception.Setting
{
    [Serializable]
    internal class SettingServerAddressLengthException : System.Exception
    {
        public SettingServerAddressLengthException()
        {
        }

        public SettingServerAddressLengthException(string? name) 
            : base($"Server address {name} cannot be longer than the specified length")
        {
        }

        public SettingServerAddressLengthException(string? message, System.Exception? innerException) 
            : base(message, innerException)
        {
        }
    }
}