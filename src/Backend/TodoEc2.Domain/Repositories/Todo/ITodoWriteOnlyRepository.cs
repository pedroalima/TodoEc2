namespace TodoEc2.Domain.Repositories.Todo
{
    public interface ITodoWriteOnlyRepository
    {
        public Task Add(Domain.Entities.Todo todo);
    }
}
