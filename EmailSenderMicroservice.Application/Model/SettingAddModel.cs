namespace EmailSenderMicroservice.Application.Model
{
    public record SettingAddModel(
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password);
}
