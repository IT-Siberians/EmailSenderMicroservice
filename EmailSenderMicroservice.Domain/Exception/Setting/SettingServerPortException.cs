namespace EmailSenderMicroservice.Domain.Exception.Setting
{
    internal class SettingServerPortException : ArgumentException
    {
        public SettingServerPortException()
        {
        }

        public SettingServerPortException(string? message, string? value)
            : base(message, value)
        {
        }

        public SettingServerPortException(string? message, ArgumentException? innerException) 
            : base(message, innerException)
        {
        }
    }
}