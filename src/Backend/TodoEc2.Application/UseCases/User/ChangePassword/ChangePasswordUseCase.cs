using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoEc2.Application.Services.Cryptografy;
using TodoEc2.Application.UseCases.User.Update;
using TodoEc2.Communication.Requests;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Domain.Service.LoggedUser;
using TodoEc2.Exceptions.ExceptionBase;

namespace TodoEc2.Application.UseCases.User.ChangePassword
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly PasswordEncrypter _passwordEncrypter;
        private readonly IUserUpdateOnlyRepository _repository;
        private readonly IUnityOfWork _unityOfWork;

        public ChangePasswordUseCase(
            ILoggedUser loggedUser,
            PasswordEncrypter passwordEncrypter,
            IUserUpdateOnlyRepository repository,
            IUnityOfWork unityOfWork)
        {
            _loggedUser = loggedUser;
            _passwordEncrypter = passwordEncrypter;
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task Execute(RequestChangePasswordJson request)
        {
            var loggedUser = await _loggedUser.User();

            Validate(request, loggedUser);

            var user = await _repository.GetById(loggedUser.Id);

            user.Password = _passwordEncrypter.Encrypt(request.NewPassword);

            _repository.Update(user);

            await _unityOfWork.Commit();
        }

        private void Validate(RequestChangePasswordJson request, Domain.Entities.User loggedUser)
        {
            var result = new ChangePasswordValidator().Validate(request);

            var currentPasswordEncripted = _passwordEncrypter.Encrypt(request.Password);

            if (!currentPasswordEncripted.Equals(loggedUser.Password))
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "Email e/ou senha inválidos!"));

            if (!result.IsValid)
                throw new ErrorOnValidationException(result.Errors.Select(e => e.ErrorMessage).ToList());
        }
    }
}
