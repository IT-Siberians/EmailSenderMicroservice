using EmailSenderMicroservice.Domain.ValueObject;

namespace EmailSenderMicroservice.Contracts.Setting
{
    public record SettingRequest(
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password);
}
