using AutoMapper;
using eCommerce.Communication.Request;
using eCommerce.Domain.Models;

namespace eCommerce.Application.Services.AutoMapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<UserRegisterRequest, User>()
            .ForMember(c => c.Password, opt =>
                opt.Ignore());
    }
}