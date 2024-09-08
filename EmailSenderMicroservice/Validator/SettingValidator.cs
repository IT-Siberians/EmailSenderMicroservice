using EmailSenderMicroservice.Contracts.Setting;
using EmailSenderMicroservice.Domain.Helpers;
using EmailSenderMicroservice.Domain.ValueObjects;
using FluentValidation;

namespace EmailSenderMicroservice.Validator
{
    public class SettingValidator : AbstractValidator<SettingRequest>
    {
        public SettingValidator()
        {
            RuleFor(setting => setting.ServerAddress)
                .NotNull()
                .NotEmpty()
                .Length(10, Connection.MAX_SERVER_ADDRESS_LENGTH)
                .Matches(StringValues.REGEX_ADDRESS);

            RuleFor(setting => (int)setting.ServerPort)
                .InclusiveBetween(1, 65535)
                .WithMessage(StringValues.ERROR_SERVER_PORT);

            RuleFor(setting => setting.Login)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(setting => setting.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}