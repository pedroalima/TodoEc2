using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TodoEc2.Domain.Entities;
using TodoEc2.Domain.Security.Tokens;
using TodoEc2.Domain.Service.LoggedUser;
using TodoEc2.Infrastructure.DataAccess;

namespace TodoEc2.Infrastructure.Services.LoggedUser
{
    public class LoggedUser : ILoggedUser
    {
        private readonly TodoEc2DbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUser(TodoEc2DbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }

        public async Task<User> User()
        {
            var token = _tokenProvider.Value();

            var tokeHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokeHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Sid).Value;

            var userIdentifier = Guid.Parse(identifier);

            return await _dbContext
                .Users
                .AsNoTracking()
                .FirstAsync(user => user.Active && user.UserIdentifier == userIdentifier);
        }
    }
}
