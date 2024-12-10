using TodoEc2.Application.Services.AutoMapper;
using TodoEc2.Application.Services.Cryptografy;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserReadOnlyRepository _readOnlyRepository;
        private readonly IUserWriteOnlyRepository _writeOnlyRepository;

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            // Validade
            Validate(request);

            // Mapping
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            var user = autoMapper.Map<Domain.Entities.User>(request);

            // Criptografy
            var passwordCryptografy = new PasswordEncrypter();

            passwordCryptografy.Encrypt(request.Password);

            // Save DB
            await _writeOnlyRepository.Add(user);

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
