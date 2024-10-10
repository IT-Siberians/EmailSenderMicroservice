namespace EmailSenderMicroservice.Domain.ValueObjects.Abstraction
{
    /// <summary>
    /// Абстрактный класс для представления строкового значения объекта.
    /// </summary>
    public abstract class StringValueObject
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="StringValueObject"/>.
        /// </summary>
        /// <param name="value">Строка, представляющая значение объекта.</param>
        protected StringValueObject(string value)
        {
            IsValid(value);

            Value = value;
        }

        /// <summary>
        /// Получает значение объекта.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Проверяет, соответствует ли переданная строка формату корректного значения объекта.
        /// </summary>
        /// <param name="value">Строка для проверки.</param>
        protected abstract void IsValid(string value);

        /// <summary>
        /// Возвращает строковое представление значения объекта.
        /// </summary>
        /// <returns>Строковое представление значения объекта.</returns>
        public override string ToString() => Value;

        /// <summary>
        /// Определяет, равен ли текущий объект <see cref="StringValueObject"/> другому объекту <see cref="StringValueObject"/>.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns><c>true</c>, если текущий объект равен другому объекту; в противном случае <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return obj is StringValueObject other
                && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        /// <summary>
        /// Перегруженный оператор равенства для сравнения двух объектов <see cref="StringValueObject"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="StringValueObject"/>.</param>
        /// <param name="right">Второй объект <see cref="StringValueObject"/>.</param>
        /// <returns><c>true</c>, если оба объекта равны; в противном случае <c>false</c>.</returns>
        public static bool operator ==(StringValueObject left, StringValueObject right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Перегруженный оператор неравенства для сравнения двух объектов <see cref="StringValueObject"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="StringValueObject"/>.</param>
        /// <param name="right">Второй объект <see cref="StringValueObject"/>.</param>
        /// <returns><c>true</c>, если объекты не равны; в противном случае <c>false</c>.</returns>
        public static bool operator !=(StringValueObject left, StringValueObject right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Возвращает хеш-код для текущего объекта <see cref="StringValueObject"/>.
        /// </summary>
        /// <returns>Хеш-код для текущего объекта.</returns>
        public override int GetHashCode() => StringComparer.Ordinal.GetHashCode(Value);
    }
}