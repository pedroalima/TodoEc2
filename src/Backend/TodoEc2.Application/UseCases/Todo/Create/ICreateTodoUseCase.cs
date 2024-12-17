using TodoEc2.API.Controllers;
using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.Todo.Create
{
    public interface ICreateTodoUseCase
    {
        public Task<ResponseCreateTodoJson> Execute(RequestCreateTodoJson request);
    }
}