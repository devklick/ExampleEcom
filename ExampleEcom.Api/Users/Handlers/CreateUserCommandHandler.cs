using AutoMapper;
using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExampleEcom.Api.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CreateUserCommandHandler(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.Data);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.Data.Password);
            var result = await _userManager.CreateAsync(user);
            var response = _mapper.Map<CreateUserResponse>(user);
            return response;
        }
    }
}
