﻿namespace EmailSenderMicroservice.Application.Models.Setting
{
    public record AddSettingModel(
        string ServerAddress,
        uint ServerPort,
        bool UseSSL,
        string Login,
        string Password);
}
