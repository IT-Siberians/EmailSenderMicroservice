namespace EmailSenderMicroservice.Domain.Helpers
{
    public static class StringValues
    {
        public const string REGEX_EMAIL = @"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}";
        public const string REGEX_ADDRESS = @"^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\.)+[A-Za-z]{2,6}$";
        public const string ERROR_EMAIL = "Email is not valid. Current value '{1}'.";
        public const string ERROR_SERVER_PORT = "The port must be in the range from 1 to 65535.";
        public const string ERROR_SERVER_ADDRESS = "Server address cannot be empty.";
        public const string ERROR_SERVER_ADDRESS_LENGTH = "The minimum length of the server address must be in the range from 10 to {0} characters. Current value '{1}'.";
        public const string ERROR_SERVER_PASS = "Password cannot be empty.";
        public const string ERROR_SERVER_LOGIN = "Login cannot be empty or does not meet the requirements.";
        public const string ERROR_ID = "Identifier cannot be empty.";
        public const string ERROR_TEXT = "Text cannot be empty.";
        public const string ERROR_TYPE = "Type cannot be empty.";
    }
}
