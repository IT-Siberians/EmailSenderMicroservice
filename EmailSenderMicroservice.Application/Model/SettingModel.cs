namespace EmailSenderMicroservice.Application.Model
{
    public record SettingModel(
        Guid Id,
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password,
        DateTime CreateDate);
}
