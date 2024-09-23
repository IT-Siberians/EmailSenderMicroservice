using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.Helpers;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Domain.ValueObjects
{
    /// <summary>
    /// Класс, представляющий соединение с сервером отправки email.
    /// </summary>
    /// <exception cref="SettingServerAddressNullOrEmptyException">
    /// Исключение, возникающее при пустом значении адреса сервера.
    /// </exception>
    /// <exception cref="SettingServerAddressLengthException">
    /// Исключение, возникающее при превышении максимальной длины адреса сервера.
    /// </exception>
    /// <exception cref="SettingServerPortException">
    /// Исключение, возникающее при несоответствии значения порта сервера.
    /// </exception>
    public class Connection
    {
        public const int MAX_SERVER_ADDRESS_LENGTH = 30;

        /// <summary>
        /// Регулярное выражение для проверки валидности адреса сервера.
        /// </summary>
        private static readonly Regex ValidationAddressRegex = new Regex(
                StringValues.REGEX_ADDRESS,
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Основной конструктор класса Connection.
        /// </summary>
        /// <param name="address">Адрес сервера.</param>
        /// <param name="port">Порт сервера.</param>
        /// <exception cref="SettingServerAddressNullOrEmptyException">
        /// Исключение, возникающее при пустом значении адреса сервера.
        /// </exception>
        /// <exception cref="SettingServerAddressLengthException">
        /// Исключение, возникающее при превышении максимальной длины адреса сервера.
        /// </exception>
        /// <exception cref="SettingServerPortException">
        /// Исключение, возникающее при несоответствии значения порта сервера.
        /// </exception>
        public Connection(string address, uint port)
        {
            if (!IsValidAddress(address))
            {
                throw new SettingServerAddressNullOrEmptyException(address);
            }

            if (address.Length > MAX_SERVER_ADDRESS_LENGTH)
            {
                throw new SettingServerAddressLengthException(MAX_SERVER_ADDRESS_LENGTH, address.Length.ToString());
            }

            if (!IsValidPort(port))
            {
                throw new SettingServerPortException(port.ToString());
            }

            Address = address;
            Port = port;
        }

        /// <summary>
        /// Адрес сервера.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Порт сервера.
        /// </summary>
        public uint Port { get; }

        /// <summary>
        /// Проверяет валидность переданного адреса.
        /// </summary>
        /// <param name="value">Адрес сервера.</param>
        /// <returns>Булевое значение, указывающее на валидность адреса.</returns>
        private bool IsValidAddress(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationAddressRegex.IsMatch(value);
        }

        /// <summary>
        /// Проверяет валидность переданного значения порта (1 <= port <= 65535).
        /// </summary>
        /// <param name="value">Значение порта.</param>
        /// <returns>Булевое значение, указывающее на валидность порта.</returns>
        private bool IsValidPort(uint value)
        {
            return value >= 1 && value <= 65535;
        }

        /// <summary>
        /// Переопределенный метод Equals.
        /// </summary>
        /// <param name="obj">Объект для сравнения.</param>
        /// <returns>Булевое значение, указывающее на равенство объектов.</returns>
        public override bool Equals(object obj)
        {
            return obj is Connection other
                && StringComparer.Ordinal.Equals(Address, other.Address)
                && Port == other.Port;
        }

        /// <summary>
        /// Перегруженный оператор равенства для сравнения двух объектов <see cref="Connection"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Connection"/>.</param>
        /// <param name="right">Второй объект <see cref="Connection"/>.</param>
        /// <returns><c>true</c>, если оба объекта равны; в противном случае <c>false</c>.</returns>
        public static bool operator ==(Connection left, Connection right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);
            return left.Equals(right);
        }

        /// <summary>
        /// Перегруженный оператор неравенства для сравнения двух объектов <see cref="Connection"/>.
        /// </summary>
        /// <param name="left">Первый объект <see cref="Connection"/>.</param>
        /// <param name="right">Второй объект <see cref="Connection"/>.</param>
        /// <returns><c>true</c>, если объекты не равны; в противном случае <c>false</c>.</returns>
        public static bool operator !=(Connection left, Connection right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Переопределенный метод GetHashCode.
        /// </summary>
        /// <returns>Хэш-код объекта.</returns>
        public override int GetHashCode() => HashCode.Combine(Address.GetHashCode(), Port.GetHashCode());

    }
}