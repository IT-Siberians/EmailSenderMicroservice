using EmailSenderMicroservice.Domain.Interface.Model;
using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Domain.Models
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Setting : IEntity<Guid>
    {
        public const int MAX_SERVER_ADDRESS_LENG = 30;

        private Guid _id;
        private string _serverAddress;
        private uint _serverPort;
        private bool _useSSL;
        private Email _login;
        private string _password;
        private DateTime _createDate;


        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get => _id; }

        /// <summary>
        /// Адрес сервера оправки почты
        /// </summary>
        public string ServerAddress { get => _serverAddress; }

        /// <summary>
        /// Порт сервера оправки почты
        /// </summary>
        public uint ServerPort { get => _serverPort; }

        /// <summary>
        /// Признак использования SSL сервером оправки почты
        /// </summary>
        public bool UseSSL { get => _useSSL; }

        /// <summary>
        /// Логин от ящика для отправки
        /// </summary>        
        public Email Login { get => _login; }

        /// <summary>
        /// Пароль от ящика отправки
        /// </summary>
        public string Password { get => _password; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }
        
        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="serverAddress">адрес сервера отправки сообщений</param>
        /// <param name="serverPort">порт сервера отправки сообщений</param>
        /// <param name="useSSl">признак использования SSL</param>
        /// <param name="login">логин учетной записи отправителя</param>
        /// <param name="password">пароль от учетной записи отпраителя</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Сущность (Настройки для сервиса отправления сообщений на Email)</returns>
        private Setting(Guid id, string serverAddress, uint serverPort, bool useSSl, string login, string password, DateTime createDate)
        {
            if (id == Guid.Empty)
            {
                throw new SettingGuidEmptyException(nameof(id));
            }

            if (string.IsNullOrEmpty(serverAddress))
            {
                throw new SettingServerAddressNullOrEmptyException(nameof(serverAddress));
            }
            if (serverAddress.Length > MAX_SERVER_ADDRESS_LENG)
            {
                throw new SettingServerAddressLengthException(nameof(serverAddress));
            }

            if ((serverPort) > 0 && (serverPort % 100 != 0))
            {
                throw new SettingServerPortException(nameof(serverPort));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new SettingPasswordNullOrEmptyException(nameof(password));
            }

            _id = id;
            _serverAddress = serverAddress;
            _serverPort = serverPort;
            _useSSL = useSSl;
            _login = new Email(login);
            _password = password;
            _createDate = createDate;
        }
    }
}
