using EmailSenderMicroservice.Domain.Exception.VoalueObject;
using EmailSenderMicroservice.Domain.Resources;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Domain.ValueObject
{
    public class Email
    {

        private static readonly Regex ValidationRegex = new Regex(
                StringResources.REGEX_EMAIL,
                RegexOptions.Singleline | RegexOptions.Compiled);

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new EmailInvalidException(StringResources.ERROR_EMAIL, value);
            }

            Value = value;
        }

        public string Value { get; }

        private bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }

        public override bool Equals(object obj)
        {
            return obj is Email other &&
                   StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }
    }
}
