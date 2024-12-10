namespace TodoEc2.Domain.Repositories.User
{
    public interface IUserWriteOnlyRepository
    {
        public Task Add(Entities.User user);
    }
}
