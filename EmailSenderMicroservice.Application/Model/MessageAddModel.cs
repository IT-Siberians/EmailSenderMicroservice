namespace EmailSenderMicroservice.Application.Model
{
    public record MessageAddModel(
        string Email,
        string MessageType,
        string MessageText);
}
