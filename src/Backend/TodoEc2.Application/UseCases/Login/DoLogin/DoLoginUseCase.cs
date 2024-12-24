using TodoEc2.Application.Services.Cryptografy;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly PasswordEncrypter _passwordEncrypter;

        public DoLoginUseCase(IUserReadOnlyRepository repository, PasswordEncrypter passwordEncrypter)
        {
            _repository = repository;
            _passwordEncrypter = passwordEncrypter;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var encriptedPassword = _passwordEncrypter.Encrypt(request.Password);

            var user = await _repository.GetByEmailAndPassword(request.Email, encriptedPassword) 
                ?? throw new InvalidLoginException();

            return new ResponseRegisterUserJson
            {
                Name = user.Name
            };
        }
    }
}
