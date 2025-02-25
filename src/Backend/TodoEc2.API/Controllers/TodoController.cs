﻿using Microsoft.AspNetCore.Mvc;
using TodoEc2.Application.UseCases.Todo.Create;
using TodoEc2.Communication.Responses;

namespace TodoEc2.API.Controllers
{
    public class TodoController : TodoEc2BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseCreateTodoJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateTodoUseCase useCase,
            [FromBody] RequestCreateTodoJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
