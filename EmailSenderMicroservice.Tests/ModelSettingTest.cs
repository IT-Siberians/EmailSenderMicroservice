using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.Helpers;
using EmailSenderMicroservice.Domain.ValueObject;
using Xunit;

namespace EmailSenderMicroservice.Tests
{
    public class ModelSettingTest
    {
        [Fact]
        public void Constructor_Should_Create_Setting_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var serverAdress = "ya.ru";
            uint serverPort = 477;
            var connection = new Connection(serverAdress, serverPort);
            var login = new Email("ya@ya.ru");
            var password = "12345";
            var createDate = DateTime.Now;

            // Act
            var setting = new Setting(id, connection, true, login, password, createDate);

            // Assert
            Assert.Equal(id, setting.Id);
            Assert.Equal(serverAdress, setting.Connection.Address);
            Assert.Equal(serverPort, setting.Connection.Port);
            Assert.True(setting.UseSSL);
            Assert.Equal(login, setting.Login);
            Assert.Equal(password, setting.Password);
            Assert.Equal(createDate, setting.CreatedDate);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Password_IsNullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var serverAdress = "ya.ru";
            uint serverPort = 477;
            var connection = new Connection(serverAdress, serverPort);
            var login = new Email("ya@ya.ru");
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<SettingPasswordNullOrEmptyException>(() =>
                new Setting(id, connection, true, login, string.Empty, createDate));
            Assert.Equal(StringValue.ERROR_SERVER_PASS, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Password_WhiteSpace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var serverAdress = "ya.ru";
            uint serverPort = 477;
            var connection = new Connection(serverAdress, serverPort);
            var login = new Email("ya@ya.ru");
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<SettingPasswordNullOrEmptyException>(() =>
                new Setting(id, connection, true, login, "  ", createDate));
            Assert.Equal(StringValue.ERROR_SERVER_PASS + " (Parameter '  ')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Id_IsEmpty()
        {
            // Arrange
            var id = Guid.Empty;
            var serverAdress = "ya.ru";
            uint serverPort = 477;
            var connection = new Connection(serverAdress, serverPort);
            var login = new Email("ya@ya.ru");
            var password = "12345";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<SettingGuidEmptyException>(() =>
                new Setting(id, connection, true, login, password, createDate));
            Assert.Equal(StringValue.ERROR_ID + $" (Parameter '{id}')", exception.Message);
        }
    }
}

