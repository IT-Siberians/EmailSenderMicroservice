namespace EmailSenderMicroservice.Application.Models.Setting
{
    public record SettingModel(
        Guid Id,
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password,
        DateTime CreationDate);
}
