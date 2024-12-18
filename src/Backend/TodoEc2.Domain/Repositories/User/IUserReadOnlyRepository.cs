namespace TodoEc2.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExistActiveUserWithEmail(string email);

        public Task<Entities.User?> GetByEmailAndPassword(string email, string password);
    }
}
