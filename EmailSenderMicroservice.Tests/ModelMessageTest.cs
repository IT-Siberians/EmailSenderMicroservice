using EmailSenderMicroservice.Domain.Exception.Message;
using EmailSenderMicroservice.Domain.Models;
using Xunit;

namespace EmailSenderMicroservice.Tests
{
    public class ModelMessageTest
    {
        private readonly Guid _guidEmpty = Guid.Empty;
        private readonly Guid _guidTest = Guid.NewGuid();
        private readonly string _email = "test@test.ru";
        private readonly string _messageType = "Тема сообщения";
        private readonly string _messageText = "Текст сообщения";
        private readonly DateTime _now = DateTime.Now;

        [Fact]
        public void MessageCreateOk()
        {
            var message = new Message(_guidTest, _email, _messageType, _messageText, true, _now);

            Assert.Equal(_guidTest, message.Id);
            Assert.Equal(_email, message.Email.Value);
            Assert.Equal(_messageType, message.MessageType);
            Assert.Equal(_messageText, message.MessageText);
            Assert.Equal(_now, message.CreateDate);
        }

        [Fact]
        public async Task ExceptionGuidEmpty()
        {
            await Assert.ThrowsAsync<MessageGuidEmptyException>(() => MethodGuidEmpty());
        }

        [Fact]
        public async Task ExceptionTypeNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTypeNullOrEmptyException>(() => MethodMessageTypeNullOrEmpty());
        }

        [Fact]
        public async Task ExceptionTextNullOrEmpty()
        {
            await Assert.ThrowsAsync<MessageTextNullOrEmptyException>(() => MethodMessageTextNullOrEmpty());
        }

        private Task MethodGuidEmpty()
        {
            throw new MessageGuidEmptyException("Null GUID", _guidTest.ToString());
        }
        private Task MethodMessageTypeNullOrEmpty()
        {
            throw new MessageTypeNullOrEmptyException("Null Type", _messageType);
        }
        private Task MethodMessageTextNullOrEmpty()
        {
            throw new MessageTextNullOrEmptyException("Null Text", _messageText);
        }
    }
}
