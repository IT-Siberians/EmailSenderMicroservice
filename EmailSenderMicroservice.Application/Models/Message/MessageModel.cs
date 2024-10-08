﻿using EmailSenderMicroservice.Application.Models.Abstraction;

namespace EmailSenderMicroservice.Application.Models.Message
{
    public record MessageModel(
        Guid Id,
        string Email,
        string MessageType,
        string MessageText,
        bool Status,
        DateTime CreationDate) : IModel<Guid>;
}
