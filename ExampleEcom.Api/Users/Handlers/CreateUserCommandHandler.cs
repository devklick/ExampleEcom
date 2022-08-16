using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Repository;
using MapsterMapper;
using MediatR;

namespace ExampleEcom.Api.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var result = await _userRepository.Create(user);
            var response = _mapper.Map<CreateUserResponse>(result);
            return response;
        }
    }
}
