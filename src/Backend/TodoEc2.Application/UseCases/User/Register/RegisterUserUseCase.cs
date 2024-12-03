using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
        {
            // Validade

            // Mapping
            // Criptografy
            // Save DB

            return new ResponseRegisterUserJson
            {
                Name = request.Name
            };
        }
    }
}
