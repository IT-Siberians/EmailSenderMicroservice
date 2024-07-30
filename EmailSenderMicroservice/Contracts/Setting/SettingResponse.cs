namespace EmailSenderMicroservice.Contracts.Setting
{
    public record SettingResponse(
        Guid Id,
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password,
        DateTime CreateDate
        );
}
