namespace EmailSenderMicroservice.Contracts.Message
{
    public record MessageResponse(
        Guid Id,
        string Email,
        string MessageType,
        string MessageText,
        bool Status,
        DateTime CreationDate);
}
