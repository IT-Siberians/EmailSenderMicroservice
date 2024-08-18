using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.ValueObject;
using EmailSenderMicroservice.Domain.Helpers;
using EmailSenderMicroservice.Domain.Entities.Base;

namespace EmailSenderMicroservice.Domain.Entities
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public class Setting : IEntity<Guid>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Адрес сервера оправки почты
        /// </summary>
        public Connection Connection { get; }

        /// <summary>
        /// Признак использования SSL сервером оправки почты
        /// </summary>
        public bool UseSSL { get; }

        /// <summary>
        /// Логин от ящика для отправки
        /// </summary>        
        public Email Login { get; }

        /// <summary>
        /// Пароль от ящика отправки
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime CreateDate { get; }

        /// <summary>
        /// Пустой конструктор для EF Core
        /// </summary>
        protected Setting() { }

        /// <summary>
        /// Основной конструктор класса
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="connection">объект содержащий в себе адрес и порт сервера отправки сообщений</param>
        /// <param name="useSSL">признак использования SSL</param>
        /// <param name="login">логин учетной записи отправителя</param>
        /// <param name="password">пароль от учетной записи отпраителя</param>
        /// <param name="createDate">дата и время отправления сообщения</param>
        /// <returns>Сущность (Настройки для сервиса отправления сообщений на Email)</returns>
        /// <exception cref="SettingGuidEmptyException">Исключение на соответсвие идентификатора</exception>        
        /// <exception cref="SettingPasswordNullOrEmptyException">Исключение пустого значения параметра пароля</exception>
        public Setting(Guid id, Connection connection, bool useSSL, Email login, string password, DateTime createDate)
        {
            if (id == Guid.Empty)
            {
                throw new SettingGuidEmptyException(StringValue.ERROR_ID, id.ToString());
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new SettingPasswordNullOrEmptyException(StringValue.ERROR_SERVER_PASS, password.ToString());
            }

            Id = id;
            Connection = connection;
            UseSSL = useSSL;
            Login = login;
            Password = password;
            CreateDate = createDate;
        }
    }
}
