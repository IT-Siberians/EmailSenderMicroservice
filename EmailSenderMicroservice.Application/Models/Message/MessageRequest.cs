namespace EmailSenderMicroservice.Application.Models.Message
{
    public record MessageRequest(
        string Name,
        string Email,
        string MessageType,
        string MessageText);
}
