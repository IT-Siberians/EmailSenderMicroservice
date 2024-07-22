using NotificationMicroservice.Domain.Exception.VoalueObject;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.Domain.ValueObject
{
    public class Email
    {

        private static readonly Regex ValidationRegex = new Regex(
        @"[.\-_a-z0-9]+@([a-z0-9][\-a-z0-9]+\.)+[a-z]{2,6}",
        RegexOptions.Singleline | RegexOptions.Compiled);

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new EmailInvalidException(nameof(value));
            }

            Value = value;
        }

        public string Value { get; }

        public static bool IsValid(string value)
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
