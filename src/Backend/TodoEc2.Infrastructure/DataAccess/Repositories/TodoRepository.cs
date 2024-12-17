using TodoEc2.Domain.Entities;
using TodoEc2.Domain.Repositories.Todo;

namespace TodoEc2.Infrastructure.DataAccess.Repositories
{
    public class TodoRepository : ITodoWriteOnlyRepository
    {
        private readonly TodoEc2DbContext _dbContext;
        
        public TodoRepository(TodoEc2DbContext dbContext) => _dbContext = dbContext;

        public async Task Add(Todo todo) => await _dbContext.AddAsync(todo);
    }
}
