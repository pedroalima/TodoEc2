using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;

namespace TodoEc2.Application.SharedValidators
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                context.MessageFormatter.AppendArgument("ErrorMessage", "A senha não pode ser vazia!");

                return false;
            }

            if (password.Length < 6)
            {
                context.MessageFormatter.AppendArgument("ErrorMessage", "A senha deve conter pelo menos 6 caracteres!");
                
                return false;
            }

            return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode) => "{ErrorMessage}";
    }
}
