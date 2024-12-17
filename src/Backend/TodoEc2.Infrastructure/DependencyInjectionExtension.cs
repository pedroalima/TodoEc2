using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoEc2.Domain.Repositories;
using TodoEc2.Domain.Repositories.Todo;
using TodoEc2.Domain.Repositories.User;
using TodoEc2.Infrastructure.DataAccess;
using TodoEc2.Infrastructure.DataAccess.Repositories;

namespace TodoEc2.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddDbContext(service);
            AddRepositories(service);
        }

        public static void AddDbContext(IServiceCollection service)
        {
            var connectionString = "Data Source=PEDRO;Initial Catalog=todoec2;User ID=sa;Password=Azsxd@626;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

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
            
            service.AddScoped<ITodoWriteOnlyRepository, TodoRepository>();
        }
    }
}
