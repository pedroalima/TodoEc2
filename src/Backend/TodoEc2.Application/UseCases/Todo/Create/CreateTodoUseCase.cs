using AutoMapper;
using TodoEc2.API.Controllers;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Repositories;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.Todo.Create
{
    public class CreateTodoUseCase : ICreateTodoUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public CreateTodoUseCase(
            IMapper mapper,
            IUnityOfWork unityOfWork)
        {
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }
        public ResponseCreateTodoJson Execute(RequestCreateTodoJson request)
        {
            Validate(request);

            var todo = _mapper.Map<Domain.Entities.Todo>(request);

            return new ResponseCreateTodoJson
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status
            };
        }

        private void Validate(RequestCreateTodoJson request)
        {
            var validator = new CreateTodoValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }

        }
    }
}
