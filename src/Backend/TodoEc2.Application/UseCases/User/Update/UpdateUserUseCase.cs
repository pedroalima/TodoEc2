using TodoEc2.Communication.Requests;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Service.LoggedUser;

namespace TodoEc2.Application.UseCases.User.Update
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateUserUseCase(
            ILoggedUser loggedUser,
            IUnityOfWork unityOfWork)
        {
            _loggedUser = loggedUser;
            _unityOfWork = unityOfWork;
        }
        public async Task Execute(RequestUpdateUserJson request)
        {
            var user = _loggedUser.User();
        }
    }
}
