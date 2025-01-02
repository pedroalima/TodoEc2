using TodoEc2.Domain.Entities;

namespace TodoEc2.Domain.Service.LoggedUser
{
    public interface ILoggedUser
    {
        public Task<User> User();
    }
}