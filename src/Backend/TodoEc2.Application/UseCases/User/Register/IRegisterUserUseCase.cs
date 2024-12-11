using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
    }
}
