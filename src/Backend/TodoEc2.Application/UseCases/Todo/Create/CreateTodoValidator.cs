using FluentValidation;
using TodoEc2.API.Controllers;

namespace TodoEc2.Application.UseCases.Todo.Create
{
    public class CreateTodoValidator : AbstractValidator<RequestCreateTodoJson>
    {
        public CreateTodoValidator()
        {
            RuleFor(todo => todo.Title).NotEmpty().WithMessage("A tarefa deve conter um título");
            RuleFor(todo => todo.Status).NotEmpty().WithMessage("Escolha uma das opções de status");
        }
    }
}
