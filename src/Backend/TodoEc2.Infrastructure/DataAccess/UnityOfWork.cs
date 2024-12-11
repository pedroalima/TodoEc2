using TodoEc2.Domain.Repositories;

namespace TodoEc2.Infrastructure.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly TodoEc2DbContext _dbContext;

        public UnityOfWork(TodoEc2DbContext dbContext) => _dbContext = dbContext;

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
