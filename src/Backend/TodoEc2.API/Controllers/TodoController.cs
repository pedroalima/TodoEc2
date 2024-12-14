using Microsoft.AspNetCore.Mvc;
using TodoEc2.Application.UseCases.Todo.Create;

namespace TodoEc2.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(
            [FromServices] ICreateTodoUseCase useCase,
            [FromBody] RequestCreateTodoJson request)
        {
            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
