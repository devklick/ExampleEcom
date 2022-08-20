using AutoMapper;
using ExampleEcom.Api.Common;
using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Common;
using ExampleEcom.Domain.Extensions;
using ExampleEcom.Domain.Repository;
using MediatR;

namespace ExampleEcom.Api.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<CreateUserResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository repository, ILogger<CreateUserCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApiResponse<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.Data);
            var result = await _repository.CreateUser(user, request.Data.Password);
            return CreateResponse(result);
        }

        private ApiResponse<CreateUserResponse> CreateResponse(Result<User> userResult)
        {
            var response = new ApiResponse<CreateUserResponse>
            {
                Value = userResult.Data != null ? _mapper.Map<CreateUserResponse>(userResult.Data) : null,
                StatusCode = 201
            };

            if (userResult.Errors != null)
            {
                response.Errors = new Dictionary<string, HashSet<string>>();

                foreach (var error in userResult.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        response.StatusCode = 400;
                        response.AddError(nameof(CreateUserRequest.UserName).ToCamelCase(), error.Description);
                    }
                    else if (error.Code == "DuplicateEmail")
                    {
                        response.StatusCode = 400;
                        response.AddError(nameof(CreateUserRequest.Email).ToCamelCase(), error.Description);
                    }
                    else
                    {
                        response.StatusCode = 500;
                        _logger.LogWarning("Unhandled error code: {code} ({description})", error.Code, error.Description);
                        response.AddError(".", error.Description);
                    }
                }
            }

            return response;
        }
    }
}
