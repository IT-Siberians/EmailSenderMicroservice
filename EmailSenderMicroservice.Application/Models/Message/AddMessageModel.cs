using EmailSenderMicroservice.Application.Models.Abstraction;

namespace EmailSenderMicroservice.Application.Models.Message
{
    public record AddMessageModel(
        string Email,
        string MessageType,
        string MessageText) : IAddModel;
}
