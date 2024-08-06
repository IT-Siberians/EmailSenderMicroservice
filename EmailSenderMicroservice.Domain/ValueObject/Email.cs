using EmailSenderMicroservice.Domain.Exception.VoalueObject;
using EmailSenderMicroservice.Domain.Resources;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace EmailSenderMicroservice.Domain.ValueObject
{
    /// <summary>
    /// ValueObject для проверки строки на соответсвие правилам Email
    /// </summary>
    public class Email
    {

        private static readonly Regex ValidationRegex = new Regex(
                StringValue.REGEX_EMAIL,
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Основной конструктор класса проверки Email 
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="EmailInvalidException">Исключение валидации</exception>
        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new EmailInvalidException(StringValue.ERROR_EMAIL, value);
            }

            Value = value;
        }
        /// <summary>
        /// Значение
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Проверка передоваемой строки на соответсвие правилам
        /// </summary>
        /// <param name="value">строка с Email</param>
        /// <returns>Булевое значение</returns>
        private bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }
        
        public override string ToString() => Value;

        /// <summary>
        /// Переопределенный метод Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Булевое значение</returns>
        public override bool Equals(object obj)
        {
            return obj is Email other &&
                   StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Переопределенный метод HashCode
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }
    }
}
