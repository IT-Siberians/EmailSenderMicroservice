using EmailSenderMicroservice.Domain.Exception.Setting;

namespace EmailSenderMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Класс, представляющий пароль.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Password"/> с проверкой валидности пароля.
        /// </summary>
        /// <param name="value">Значение пароля.</param>
        public Password(string value)
        {
            IsValid(value);

            Value = value;
        }

        /// <summary>
        /// Значение пароля.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Проверяет, является ли значение пароля валидным.
        /// </summary>
        /// <param name="value">Значение пароля.</param>
        /// <exception cref="SettingPasswordNullOrEmptyException">Выбрасывается, если значение пароля пустое или содержит только пробелы.</exception>
        private void IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new SettingPasswordNullOrEmptyException(value.ToString());
            }
        }

        /// <summary>
        /// Возвращает строковое представление текущего объекта <see cref="Password"/>.
        /// </summary>
        /// <returns>Строковое представление текущего объекта <see cref="Password"/>.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Определяет, являются ли два объекта <see cref="Password"/> равными.
        /// </summary>
        /// <param name="obj">Объект <see cref="Password"/> для сравнения.</param>
        /// <returns> true, если текущий объект <see cref="Password"/> равен <paramref name="obj"/>; в противном случае - false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Password other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Определяет, являются ли два объекта <see cref="Password"/> равными.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Password"/> для сравнения.</param>
        /// <param name="right">Второй объект <see cref="Password"/> для сравнения.</param>
        /// <returns> true, если <paramref name="left"/> равен <paramref name="right"/>; в противном случае - false.</returns>
        public static bool operator ==(Password left, Password right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Определяет, не являются ли два объекта <see cref="Password"/> равными.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Password"/> для сравнения.</param>
        /// <param name="right">Второй объект <see cref="Password"/> для сравнения.</param>
        /// <returns> true, если <paramref name="left"/> не равен <paramref name="right"/>; в противном случае - false.</returns>
        public static bool operator !=(Password left, Password right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хэш-код текущего объекта <see cref="Password"/>.
        /// </summary>
        /// <returns>Хэш-код текущего объекта <see cref="Password"/>.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}
