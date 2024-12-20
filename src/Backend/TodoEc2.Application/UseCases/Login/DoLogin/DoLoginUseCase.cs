using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {

            return new ResponseRegisterUserJson
            {
                Name = ""
            };
        }
    }
}
