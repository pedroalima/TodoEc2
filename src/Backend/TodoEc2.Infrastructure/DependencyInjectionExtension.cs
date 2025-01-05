using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Repositories.Todo;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Domain.Security.Tokens;
using TodoEc2.Domain.Service.LoggedUser;
using TodoEc2.Infrastructure.DataAccess;
using TodoEc2.Infrastructure.DataAccess.Repositories;
using TodoEc2.Infrastructure.Extension;
using TodoEc2.Infrastructure.Security.Tokens.Access.Generator;
using TodoEc2.Infrastructure.Security.Tokens.Access.Validator;
using TodoEc2.Infrastructure.Services.LoggedUser;

namespace TodoEc2.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            AddRepositories(service);
            AddLoggedUser(service);
            AddTokens(service, configuration);
            AddDbContext(service, configuration);
        }

        public static void AddDbContext(IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.ConnectionString();

            service.AddDbContext<TodoEc2DbContext>(dbContextOptions =>
            {
                dbContextOptions.UseSqlServer(connectionString);
            });
        }

        public static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IUnityOfWork, UnityOfWork>();

            service.AddScoped<IUserReadOnlyRepository, UserRepository>();
            service.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            service.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
            
            service.AddScoped<ITodoWriteOnlyRepository, TodoRepository>();
        }

        public static void AddTokens(IServiceCollection service, IConfiguration configuration)
        {
            // Adicionar o pacote Microsoft.Extensions.Configuration.Binder pare ter acesso ao metodo "GetValue"
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            service.AddScoped<IAccessTokenGenerator>(option => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
            service.AddScoped<IAccessTokenValidator>(option => new JwtTokenValidator(signingKey!));
        }

        public static void AddLoggedUser(IServiceCollection service)
        {
            service.AddScoped<ILoggedUser, LoggedUser>();
        }
    }
}
