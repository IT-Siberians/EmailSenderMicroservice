using EmailSenderMicroservice.Domain.Interface.Model;
using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.ValueObject;
using EmailSenderMicroservice.Domain.Exception.Resources;

namespace EmailSenderMicroservice.Domain.Models
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Setting : IEntity<Guid>
    {
        private Guid _id;
        private Connection _connection;
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
        public Connection Connection { get => _connection; }

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
        /// <param name="connection">объект содержащий в себе адрес и порт сервера отправки сообщений</param>
        /// <param name="useSSl">признак использования SSL</param>
        /// <param name="login">логин учетной записи отправителя</param>
        /// <param name="password">пароль от учетной записи отпраителя</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Сущность (Настройки для сервиса отправления сообщений на Email)</returns>
        /// <exception cref="SettingGuidEmptyException">Исключение на соответсвие идентификатора</exception>        
        /// <exception cref="SettingPasswordNullOrEmptyException">Исключение пустого значения параметра пароля</exception>
        public Setting(Guid id, Connection connection, bool useSSl, Email login, string password, DateTime createDate)
        {
            if (id == Guid.Empty)
            {
                throw new SettingGuidEmptyException(ExceptionStrings.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new SettingPasswordNullOrEmptyException(ExceptionStrings.ERROR_SERVER_PASS, password.ToString());
            }

            _id = id;
            _connection = connection;
            _useSSL = useSSl;
            _login = login;
            _password = password;
            _createDate = createDate;
        }
    }
}
