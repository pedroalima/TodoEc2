using FluentValidation;
using TodoEc2.Communication.Requests;

namespace TodoEc2.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("O nome não pode estar vazio");
            RuleFor(user => user.Email).NotEmpty().WithMessage("O e-mail não pode estar vazio");
            RuleFor(user => user.Email).EmailAddress().WithMessage("E-mail invalido");
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage("A senha deve conter no mínimo 6 caracteres");
        }
    }
}
