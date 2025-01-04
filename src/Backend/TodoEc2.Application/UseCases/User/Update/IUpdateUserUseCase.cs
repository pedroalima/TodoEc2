using TodoEc2.Communication.Requests;

namespace TodoEc2.Application.UseCases.User.Update
{
    public interface IUpdateUserUseCase
    {
        public Task Execute(RequestUpdateUserJson request);
    }
}
