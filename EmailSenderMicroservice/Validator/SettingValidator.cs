using EmailSenderMicroservice.Contracts.Setting;
using EmailSenderMicroservice.Domain.Helpers;
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
                .MinimumLength(10)
                .Matches(StringValue.REGEX_ADDRESS);

            RuleFor(setting => setting.ServerPort.ToString())
                .NotNull()
                .NotEmpty()
                .Matches(StringValue.REGEX_PORT)
                .WithMessage(StringValue.ERROR_SERVER_PORT);

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