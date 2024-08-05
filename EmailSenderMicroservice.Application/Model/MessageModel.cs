namespace EmailSenderMicroservice.Application.Model
{
    public record MessageModel(
        Guid Id,
        string Email,
        string MessageType,
        string MessageText,
        bool Status,
        DateTime CreateDate);
}
