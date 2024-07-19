using EmailSenderMicroservice.Domain.Interface.Model;
using System.Text;
using System.Text.RegularExpressions;

namespace NotificationMicroservice.Domain.Models
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
        private string _login;
        private string _passwordHash;
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
        public string Login { get => _login; }

        /// <summary>
        /// Пароль от ящика отправки
        /// </summary>
        public string PasswordHash { get => _passwordHash; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get => _createDate; }

        public Setting() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="serverAddress">адрес сервера отправки сообщений</param>
        /// <param name="serverPort">порт сервера отправки сообщений</param>
        /// <param name="useSSl">признак использования SSL</param>
        /// <param name="login">логин учетной записи отправителя</param>
        /// <param name="passwordHash">пароль от учетной записи отпраителя</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Сущность (Настройки для сервиса отправления сообщений на Email)</returns>
        private Setting(Guid id, string serverAddress, uint serverPort, bool useSSl, string login, string passwordHash, DateTime createDate)
        {
            _id = id;
            _serverAddress = serverAddress;
            _serverPort = serverPort;
            _useSSL = useSSl;
            _login = login;
            _passwordHash = passwordHash;
            _createDate = createDate;
        }

        /// <summary>
        /// Создание настроек
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="serverAddress">адрес сервера отправки сообщений</param>
        /// <param name="serverPort">порт сервера отправки сообщений</param>
        /// <param name="useSSl">признак использования SSL</param>
        /// <param name="login">логин учетной записи отправителя</param>
        /// <param name="passwordHash">пароль от учетной записи отпраителя</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Кортеж (Сущность, Ошибки)</returns>
        public (Setting Setting, string Error) Create(Guid id, string serverAddress, uint serverPort, bool useSSl, string login, string passwordHash, DateTime createDate)
        {
            var errorSb = new StringBuilder();

            if (id == Guid.Empty)
            {
                errorSb.AppendLine($"Identifier {id} cannot be empty");
            }

            if (string.IsNullOrEmpty(serverAddress) || serverAddress.Length > MAX_SERVER_ADDRESS_LENG)
            {
                errorSb.AppendLine($"Sending server address {serverAddress} cannot be empty or longer than {MAX_SERVER_ADDRESS_LENG} characters");
            }

            if ((serverPort) > 0 && (serverPort % 100 != 0))
            {
                errorSb.AppendLine($"Specified port {serverPort} cannot be negative or not a three-digit number");
            }

            if (string.IsNullOrEmpty(login) || IsValidEmail(login))
            {
                errorSb.AppendLine($"Login {login} cannot be empty or does not meet the requirements");
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                errorSb.AppendLine($"PasswordHash {passwordHash} cannot be empty");
            }

            return (new Setting(id, serverAddress, serverPort, useSSl, login, passwordHash, createDate), errorSb.ToString());
                
        }
        private bool IsValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
