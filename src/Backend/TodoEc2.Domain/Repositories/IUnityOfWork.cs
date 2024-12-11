namespace TodoEc2.Domain.Repositories
{
    public interface IUnityOfWork
    {
        public Task Commit();
    }
}
