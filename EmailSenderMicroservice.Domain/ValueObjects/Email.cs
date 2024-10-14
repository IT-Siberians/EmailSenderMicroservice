using EmailSenderMicroservice.Domain.Exception.ValueObject;
using EmailSenderMicroservice.Domain.Helpers;
using EmailSenderMicroservice.Domain.ValueObjects.Abstraction;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет электронный адрес и обеспечивает проверку его корректности. Экземпляр класса <see cref="Email"/>.
    /// </summary>
    public class Email(string value) : StringValueObject(value)
    {
        // Регулярное выражение для проверки корректности Email-адреса
        private static readonly Regex ValidationRegex = new Regex(
            StringValues.REGEX_EMAIL,
            RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Проверяет, является ли значение электронного адреса валидным.
        /// </summary>
        /// <param name="value">Значение электронного адреса.</param>
        /// <exception cref="EmailInvalidException">Выбрасывается, если значение электронного адреса некорректно.</exception>
        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !ValidationRegex.IsMatch(value))
            {
                throw new EmailInvalidException(value);
            }
        }
    }
}