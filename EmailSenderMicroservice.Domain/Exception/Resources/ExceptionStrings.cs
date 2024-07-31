namespace EmailSenderMicroservice.Domain.Exception.Resources
{
    internal class ExceptionStrings
    {
        public const string REGEX_EMAIL = @"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}";
        public const string REGEX_ADDRESS = @"^((?!-)[A-Za-z0-9-]{1,63}(?<!-)\.)+[A-Za-z]{2,6}$";
        public const string REGEX_PORT = @"\d\d\d";
        public const string ERROR_EMAIL = $"Email is not valid.";
        public const string ERROR_SERVER_PORT = $"Specified port cannot be negative or not a three-digit number.";
        public const string ERROR_SERVER_ADDRESS = $"Server address cannot be empty.";
        public const string ERROR_SERVER_ADDRESS_LENG = $"Server address cannot be longer than the specified length.";
        public const string ERROR_SERVER_PASS = $"Password cannot be empty.";
        public const string ERROR_SERVER_LOGIN = $"Login cannot be empty or does not meet the requirements.";
        public const string ERROR_ID = $"Identifier cannot be empty.";
        public const string ERROR_TEXT = $"Text cannot be empty.";
        public const string ERROR_TYPE = $"Type cannot be empty.";
    }
}
