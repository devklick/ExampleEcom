using AutoMapper;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;

namespace ExampleEcom.Api.Users.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.Roles.Select(r => r.Name)));

            CreateMap<User, UserLoginResponse>()
                .ForMember(
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => src.Roles.Select(r => r.Name)));
        }
    }
}
