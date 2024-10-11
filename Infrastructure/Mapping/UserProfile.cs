using AutoMapper;
using Core.Entities;
using Core.Request;

namespace Infrastructure.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserRequest, User>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.PassWordHash, opt => opt.MapFrom(src => src.PassWordHash));
       
    }
}
