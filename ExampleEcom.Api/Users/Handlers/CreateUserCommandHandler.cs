using AutoMapper;
using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExampleEcom.Api.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.Data);
            await _repository.CreateUser(user, request.Data.Password);
            var response = _mapper.Map<CreateUserResponse>(user);
            return response;
        }
    }
}
