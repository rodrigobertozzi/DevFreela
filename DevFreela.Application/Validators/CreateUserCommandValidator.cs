using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-mail não válido!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("Senha deve conter pelo menos 8 carecteres, um número, uma letra maiúscula, uma letra minúscula e um caracter especial");

            RuleFor(u => u.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome é obrigatório");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }
    }
}
