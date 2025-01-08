using FluentValidation;
using TodoEc2.Application.SharedValidators;
using TodoEc2.Communication.Requests;

namespace TodoEc2.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordValidator :AbstractValidator<RequestChangePasswordJson>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.Password).SetValidator(new PasswordValidator<RequestChangePasswordJson>());
        }
    }
}