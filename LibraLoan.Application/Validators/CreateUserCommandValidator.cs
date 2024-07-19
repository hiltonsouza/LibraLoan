using FluentValidation;
using LibraLoan.Application.Commands.CreateUser;
using System.Text.RegularExpressions;

namespace LibraLoan.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() {
            RuleFor(p => p.Name)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is required!");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail is not valid!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Password must have at least 8 characters with a number, an uppercase , and a special character");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
