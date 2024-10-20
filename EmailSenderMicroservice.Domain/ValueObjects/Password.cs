using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.ValueObjects.Abstraction;

namespace EmailSenderMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Класс, представляющий пароль. Экземпляр класса <see cref="Password"/>.
    /// </summary>
    /// <param name="value">Строка, представляющая пароль.</param>
    public class Password(string value) : StringValueObject(value)
    {
        /// <summary>
        /// Проверяет, является ли значение пароля валидным.
        /// </summary>
        /// <param name="value">Значение пароля.</param>
        /// <exception cref="SettingPasswordNullOrEmptyException">Выбрасывается, если значение пароля пустое или содержит только пробелы.</exception>
        protected override void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new SettingPasswordNullOrEmptyException(value.ToString());
            }
        }
    }
}