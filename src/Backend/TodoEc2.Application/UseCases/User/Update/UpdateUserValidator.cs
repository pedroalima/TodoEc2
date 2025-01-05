using FluentValidation;
using TodoEc2.Communication.Requests;

namespace TodoEc2.Application.UseCases.User.Update
{
    public class UpdateUserValidator : AbstractValidator<RequestUpdateUserJson>
    {
        public UpdateUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O campo Nome não pode ser vazio");
            RuleFor(request => request.Email).NotEmpty().WithMessage("O campo E-mail não pode ser vazio");

            When(request => !string.IsNullOrWhiteSpace(request.Email), () =>
            {
                RuleFor(request => request.Email).EmailAddress().WithMessage("Este não é um e-mail válido");
            });
        }
    }
}
