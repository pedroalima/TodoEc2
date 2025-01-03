using TodoEc2.Communication.Responses;

namespace TodoEc2.Application.UseCases.User.GetUserProfile
{
    public interface IGetUserProfileUseCase
    {
        public Task<ResponseUserProfileJson> Execute();
    }
}
