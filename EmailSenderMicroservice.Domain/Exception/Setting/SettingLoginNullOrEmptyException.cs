namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    public class SettingLoginNullOrEmptyException : ArgumentException
    {
        public SettingLoginNullOrEmptyException()
        {
        }

        public SettingLoginNullOrEmptyException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingLoginNullOrEmptyException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}