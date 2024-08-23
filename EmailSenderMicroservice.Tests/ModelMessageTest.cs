using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.Exception.Message;
using EmailSenderMicroservice.Domain.Helpers;
using EmailSenderMicroservice.Domain.ValueObject;
using Xunit;

namespace EmailSenderMicroservice.Tests
{
    public class ModelMessageTest
    {

        [Fact]
        public void Constructor_Should_Create_Message_When_Valid_Parameters()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = new Email("test@test.ru");
            var messageType = "Test type message";
            var messageText = "Test message";
            var createDate = DateTime.Now;

            // Act
            var message = new Message(id, email, messageType, messageText, true, createDate);

            // Assert
            Assert.Equal(id, message.Id);
            Assert.Equal(email, message.Email);
            Assert.Equal(messageType, message.MessageType);
            Assert.Equal(messageText, message.MessageText);
            Assert.Equal(createDate, message.CreatedDate);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Type_IsNullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = new Email("test@test.ru");
            var messageText = "Test message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeNullOrEmptyException>(() =>
                new Message(id, email, string.Empty, messageText, true, createDate));
            Assert.Equal(StringValue.ERROR_TYPE, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Type_WhiteSpace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = new Email("test@test.ru");
            var messageText = "Test message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTypeNullOrEmptyException>(() =>
                new Message(id, email, "  ", messageText, true, createDate));
            Assert.Equal(StringValue.ERROR_TYPE + " (Parameter '  ')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Text_IsNullOrEmpty()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = new Email("test@test.ru");
            var messageType = "Test type message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTextNullOrEmptyException>(() =>
                new Message(id, email, messageType, string.Empty, true, createDate));
            Assert.Equal(StringValue.ERROR_TEXT, exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Text_WhiteSpace()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = new Email("test@test.ru");
            var messageType = "Test type message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageTextNullOrEmptyException>(() =>
                new Message(id, email, messageType, " ", true, createDate));
            Assert.Equal(StringValue.ERROR_TEXT + " (Parameter ' ')", exception.Message);
        }

        [Fact]
        public void Constructor_Should_ThrowException_When_Id_IsEmpty()
        {
            // Arrange
            var id = Guid.Empty;
            var email = new Email("test@test.ru");
            var messageType = "Test type message";
            var messageText = "Test message";
            var createDate = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<MessageGuidEmptyException>(() =>
                new Message(id, email, messageType, messageText, true, createDate));
            Assert.Equal(StringValue.ERROR_ID + $" (Parameter '{Guid.Empty}')", exception.Message);
        }

    }
}
