using EmailSenderMicroservice.Domain.Exception.Resources;
using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.Exception.VoalueObject;
using System.Text.RegularExpressions;

namespace EmailSenderMicroservice.Domain.ValueObject
{
    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="SettingServerAddressNullOrEmptyException">Исключение пустого значения адреса сервиса отправки</exception>
    /// <exception cref="SettingServerAddressLengthException">Исключение привышения адреса сервиса отправки максимально разрешенному значению</exception>
    /// <exception cref="SettingServerPortException">Исключение несоответсвия разрадности значения порта сервиса отправки</exception>
    public class Connection
    {
        public const int MAX_SERVER_ADDRESS_LENG = 30;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex ValidationAddressRegex = new Regex(
                ExceptionStrings.REGEX_ADDRESS,
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex ValidationPortRegex = new Regex(
                ExceptionStrings.REGEX_PORT,
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// Основной конструктор класса проверки Email 
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="EmailInvalidException">Исключение валидации</exception>
        public Connection(string address, uint port)
        {
            if (!IsValidAddress(address))
            {
                throw new SettingServerAddressNullOrEmptyException(ExceptionStrings.ERROR_SERVER_ADDRESS, address);
            }

            if (address.Length > MAX_SERVER_ADDRESS_LENG)
            {
                throw new SettingServerAddressLengthException(ExceptionStrings.ERROR_SERVER_ADDRESS_LENG, address.ToString());
            }

            if (!IsValidPort(port))
            {
                throw new SettingServerPortException(ExceptionStrings.ERROR_SERVER_PORT, port.ToString());
            }

            Address = address;
            Port = port;
        }

        /// <summary>
        /// Адресс сервера
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Порт сервера
        /// </summary>
        public uint Port { get; }


        /// <summary>
        /// Проверка передоваемой строки на соответсвие правилам
        /// </summary>
        /// <param name="value">строка с Email</param>
        /// <returns>Булевое значение</returns>
        private bool IsValidAddress(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationAddressRegex.IsMatch(value);
        }

        /// <summary>
        /// Проверка передоваемого значения правилам (100 <= port <= 999)
        /// </summary>
        /// <param name="value">значение порта</param>
        /// <returns>Булевое значение</returns>
        private bool IsValidPort(uint value)
        {
            return (value != 0) && ValidationPortRegex.IsMatch(value.ToString());
        }

        /// <summary>
        /// Переопределенный метод Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Булевое значение</returns>
        public override bool Equals(object obj)
        {
            return obj is Connection other &&
                   StringComparer.Ordinal.Equals(Address, other.Address) &&
                   StringComparer.Ordinal.Equals(Port, other.Port);
        }

        /// <summary>
        /// Переопределенный метод HashCode
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Address.GetHashCode(), Port.GetHashCode());
        }

    }
}
