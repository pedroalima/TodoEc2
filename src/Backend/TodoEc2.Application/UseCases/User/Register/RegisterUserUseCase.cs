using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            // Validade
            Validate(request);
            // Mapping
            // Criptografy
            // Save DB

            return new ResponseRegisterUserJson
            {
                Name = request.Name
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
