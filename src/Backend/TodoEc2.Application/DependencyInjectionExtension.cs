using Microsoft.Extensions.DependencyInjection;
using TodoEc2.Application.Services.AutoMapper;
using TodoEc2.Application.Services.Cryptografy;
using TodoEc2.Application.UseCases.Login.DoLogin;
using TodoEc2.Application.UseCases.Todo.Create;
using TodoEc2.Application.UseCases.User.ChangePassword;
using TodoEc2.Application.UseCases.User.GetUserProfile;
using TodoEc2.Application.UseCases.User.Register;
using TodoEc2.Application.UseCases.User.Update;

namespace TodoEc2.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection service)
        {
            AddPasswordEncrypter(service);
            AddAutoMapper(service);
            AddUseCases(service);
        }

        public static void AddAutoMapper(IServiceCollection service)
        {
            service.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper());
        }

        public static void AddUseCases(IServiceCollection service)
        {
            service.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            service.AddScoped<ICreateTodoUseCase, CreateTodoUseCase>();
            service.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
            service.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
            service.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            service.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
        }

        public static void AddPasswordEncrypter(IServiceCollection service)
        {
            service.AddScoped(option => new PasswordEncrypter());
        }
    }
}
