using FluentValidation;
using TodoEc2.Application.SharedValidators;
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
            RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestRegisterUserJson>());
        }
    }
}
