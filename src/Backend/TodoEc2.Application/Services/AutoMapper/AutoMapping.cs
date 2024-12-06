using AutoMapper;
using TodoEc2.Communication.Requests;
using TodoEc2.Domain.Entities;

namespace TodoEc2.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }
    }
}
