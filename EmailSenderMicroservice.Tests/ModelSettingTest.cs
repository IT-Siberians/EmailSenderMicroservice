using EmailSenderMicroservice.Domain.Exception.Setting;
using EmailSenderMicroservice.Domain.Models;
using Xunit;

namespace EmailSenderMicroservice.Tests
{
    public class ModelSettingTest
    {
        private readonly Guid _guidEmpty = Guid.Empty;
        private readonly Guid _guidTest = Guid.NewGuid();
        private readonly string _serverAdress = "ya.ru";
        private readonly uint _serverPort = 477;
        private readonly string _login = "ya@ya.ru";
        private readonly string _password = "12345";
        private readonly DateTime _now = DateTime.Now;

        [Fact]
        public void SettingCreateOk()
        {
            var message = new Setting(_guidTest, _serverAdress, _serverPort, true, _login, _password, _now);

            Assert.Equal(_guidTest, message.Id);
            Assert.Equal(_serverAdress, message.ServerAddress);
            Assert.Equal(_serverPort, message.ServerPort);
            Assert.True(message.UseSSL);
            Assert.Equal(_login, message.Login.Value);
            Assert.Equal(_password, message.Password);
            Assert.Equal(_now, message.CreateDate);
        }
        [Fact]
        public void SettingCreateNotNull()
        {
            var setting = new Setting(_guidTest, _serverAdress, _serverPort, true, _login, _password, _now);

            Assert.NotNull(setting);
        }

        [Fact]
        public void SettingCreateTypeOk()
        {
            var setting = new Setting(_guidTest, _serverAdress, _serverPort, true, _login, _password, _now);

            Assert.IsType<Setting>(setting);
        }

        [Fact]
        public async Task ExceptionGuidEmpty()
        {
            await Assert.ThrowsAsync<SettingGuidEmptyException>(() => MethodGuidEmpty());
        }

        [Fact]
        public async Task ExceptionAddressNullOrEmpty()
        {
            await Assert.ThrowsAsync<SettingServerAddressNullOrEmptyException>(() => MethodAddressNullOrEmpty());
        }

        [Fact]
        public async Task ExceptionAddressLength()
        {
            await Assert.ThrowsAsync<SettingServerAddressLengthException>(() => MethodAddressLength());
        }
        [Fact]
        public async Task ExceptionPort()
        {
            await Assert.ThrowsAsync<SettingServerPortException>(() => MethodPortException());
        }

        [Fact]
        public async Task ExceptionPasswordNullOrEmpty()
        {
            await Assert.ThrowsAsync<SettingPasswordNullOrEmptyException>(() => MethodPasswordNullOrEmpty());
        }

        private Task MethodGuidEmpty()
        {
            throw new SettingGuidEmptyException("Null GUID", _guidTest.ToString());
        }
        private Task MethodAddressNullOrEmpty()
        {
            throw new SettingServerAddressNullOrEmptyException("Null ServerAdress", _serverAdress);
        }
        private Task MethodAddressLength()
        {
            throw new SettingServerAddressLengthException("Big Length ServerAdress", _serverAdress);
        }
        private Task MethodPortException()
        {
            throw new SettingServerPortException("Port is not correct", _serverPort.ToString());
        }
        private Task MethodPasswordNullOrEmpty()
        {
            throw new SettingPasswordNullOrEmptyException("Null Password", _password);
        }
    }
}

