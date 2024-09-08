using EmailSenderMicroservice.Domain.Exception.ValueObject;
using EmailSenderMicroservice.Domain.Helpers;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Представляет значение Email и обеспечивает проверку его корректности.
    /// </summary>
    public class Email
    {
        // Регулярное выражение для проверки корректности Email-адреса
        private static readonly Regex ValidationRegex = new Regex(
            StringValues.REGEX_EMAIL,
            RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Email"/>.
        /// </summary>
        /// <param name="value">Строка, представляющая Email-адрес.</param>
        /// <exception cref="EmailInvalidException">Выбрасывается, если переданная строка не соответствует формату Email.</exception>
        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new EmailInvalidException(value);
            }

            Value = value;
        }

        /// <summary>
        /// Получает значение Email-адреса.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Проверяет, соответствует ли переданная строка формату корректного Email-адреса.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        /// <returns><c>true</c>, если строка соответствует формату Email; в противном случае <c>false</c>.</returns>
        private bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }

        /// <summary>
        /// Возвращает строковое представление Email-адреса.
        /// </summary>
        /// <returns>Строковое представление Email-адреса.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="Email"/> другому объекту <see cref="Email"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><c>true</c>, если текущий объект равен другому объекту; в противном случае <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is Email other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Перегруженный оператор равенства для сравнения двух объектов <see cref="Email"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Email"/>.</param>
        /// <param name="right">Второй объект <see cref="Email"/>.</param>
        /// <returns><c>true</c>, если оба объекта равны; в противном случае <c>false</c>.</returns>
        public static bool operator ==(Email left, Email right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Перегруженный оператор неравенства для сравнения двух объектов <see cref="Email"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Email"/>.</param>
        /// <param name="right">Второй объект <see cref="Email"/>.</param>
        /// <returns><c>true</c>, если объекты не равны; в противном случае <c>false</c>.</returns>
        public static bool operator !=(Email left, Email right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хеш-код для текущего объекта <see cref="Email"/>.
        /// </summary>
        /// <returns>Хеш-код для текущего объекта.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}