namespace TodoEc2.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task ExistActiveUserWithEmail(string email);
    }
}
