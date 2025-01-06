using TodoEc2.Communication.Requests;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Domain.Service.LoggedUser;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateUserUseCase(
            ILoggedUser loggedUser,
            IUnityOfWork unityOfWork,
            IUserUpdateOnlyRepository repository,
            IUserReadOnlyRepository userReadOnlyRepository)
        {
            _loggedUser = loggedUser;
            _unityOfWork = unityOfWork;
            _repository = repository;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task Execute(RequestUpdateUserJson request)
        {
            var loggedUser = await _loggedUser.User();

            await Validate(request, loggedUser.Email);

            var user = await _repository.GetById(loggedUser.Id);

            user.Name = request.Name;
            user.Email = request.Email;

            _repository.Update(user);

            await _unityOfWork.Commit();
        }

        private async Task Validate(RequestUpdateUserJson request, string currentEmail)
        {
            var validator = new UpdateUserValidator();

            var result = validator.Validate(request);

            if (!currentEmail.Equals(request.Email)) 
            { 
                var userExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

                if (userExist)
                    result.Errors.Add(new FluentValidation.Results.ValidationFailure("email", "E-mail já registrado"));

                if (!result.IsValid)
                {
                    var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                    throw new ErrorOnValidationException(errorMessages);
                }
            }
        }
    }
}
