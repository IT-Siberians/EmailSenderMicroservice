namespace EmailSenderMicroservice.Application.Models.Message
{
    public record AddMessageModel(
        string Email,
        string MessageType,
        string MessageText);
}
