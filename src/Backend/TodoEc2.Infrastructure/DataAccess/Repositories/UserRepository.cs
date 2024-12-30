using Microsoft.EntityFrameworkCore;
using TodoEc2.Domain.Entities;
using TodoEc2.Domain.Repositories.User;

namespace TodoEc2.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly TodoEc2DbContext _dbContext;

        public UserRepository(TodoEc2DbContext dbContext) => _dbContext = dbContext;

        public async Task Add(User user) => await _dbContext.AddAsync(user);

        public async Task<bool> ExistActiveUserWithEmail(string email) => await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);

        public async Task<bool> ExistActiveUserWithIdentifier(Guid userIdentifier) => await _dbContext.Users.AnyAsync(user => user.UserIdentifier.Equals(userIdentifier) && user.Active);

        public async Task<User?> GetByEmailAndPassword(string email, string password)
        {
            return await _dbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => 
                user.Active &&
                user.Email.Equals(email) && 
                user.Password.Equals(password));
        }
    }
}
