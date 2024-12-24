using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoEc2.Application.UseCases.Login.DoLogin;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.API.Controllers
{
    public class LoginController : TodoEc2BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody]RequestLoginJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }
    }
}
