using AutoMapper;
using TodoEc2.API.Controllers;
using TodoEc2.Communication.Requests;
using TodoEc2.Communication.Responses;
using TodoEc2.Domain.Entities;

namespace TodoEc2.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
            DomainToResponse();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<RequestCreateTodoJson, Todo>();
        }

        private void DomainToResponse()
        {
            CreateMap<User, ResponseUserProfileJson>();
        }
    }
}
