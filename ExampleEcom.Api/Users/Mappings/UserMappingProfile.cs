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
            CreateMap<User, CreateUserResponse>();
        }
    }
}
