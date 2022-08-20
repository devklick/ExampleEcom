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
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ApiResponse<UserLoginResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserLoginCommandHandler> _logger;

        public UserLoginCommandHandler(IUserRepository repository, IMapper mapper, ILogger<UserLoginCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ApiResponse<UserLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Login(request.Data.UserNameOrEmail, request.Data.Password);

            return CreateApiResponse(result);
        }

        private ApiResponse<UserLoginResponse> CreateApiResponse(Result<User?> result)
        {
            var response = new ApiResponse<UserLoginResponse>
            {
                Value = result.Success ? _mapper.Map<UserLoginResponse>(result.Data) : null,
                StatusCode = 200
            };

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code == "UserNotFound")
                    {
                        response.StatusCode = 400;
                        response.AddError(nameof(UserLoginRequest.UserNameOrEmail).ToCamelCase(), error.Description);
                    }
                    else if (error.Code == "InvalidPassword")
                    {
                        response.StatusCode = 400;
                        response.AddError(nameof(UserLoginRequest.Password).ToCamelCase(), error.Description);
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
