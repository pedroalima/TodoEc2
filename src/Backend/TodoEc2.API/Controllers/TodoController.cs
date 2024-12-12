using Microsoft.AspNetCore.Mvc;

namespace TodoEc2.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(
            [FromBody] RequestCreateTodoJson request)
        {
            return Created(string.Empty, "Tarefa Criada!");
        }
    }
}
