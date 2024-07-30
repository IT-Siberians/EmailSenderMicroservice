namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    public class SettingServerAddressNullOrEmptyException : ArgumentException
    {
        public SettingServerAddressNullOrEmptyException()
        {
        }

        public SettingServerAddressNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingServerAddressNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}