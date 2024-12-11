using Microsoft.AspNetCore.Mvc;
using TodoEc2.Application.UseCases.User.Register;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserUseCase useCase,
            [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
