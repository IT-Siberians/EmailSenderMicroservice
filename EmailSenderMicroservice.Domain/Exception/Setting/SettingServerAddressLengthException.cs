namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    public class SettingServerAddressLengthException : ArgumentException
    {
        public SettingServerAddressLengthException()
        {
        }

        public SettingServerAddressLengthException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingServerAddressLengthException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}