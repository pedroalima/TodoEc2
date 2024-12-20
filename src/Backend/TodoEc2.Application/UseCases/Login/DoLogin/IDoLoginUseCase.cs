using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        public Task<ResponseRegisterUserJson> Execute(RequestLoginJson request);
    }
}