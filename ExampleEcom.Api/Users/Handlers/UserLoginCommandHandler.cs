using AutoMapper;
using ExampleEcom.Api.Common;
using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Common;
using ExampleEcom.Domain.Extensions;
using ExampleEcom.Domain.Repository;
using ExampleEcom.Infrastructure.Crypto.Jwt;
using MediatR;


namespace ExampleEcom.Api.Users.Handlers
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, ApiResponse<UserLoginResponse>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserLoginCommandHandler> _logger;
        private readonly IJwtService _jwtService;

        public UserLoginCommandHandler(IUserRepository repository, IMapper mapper, ILogger<UserLoginCommandHandler> logger, IJwtService jwtService)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<UserLoginResponse>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.Login(request.Data.UserNameOrEmail, request.Data.Password);

            return CreateApiResponse(result);
        }

        private ApiResponse<UserLoginResponse> CreateApiResponse(Result<User?> result)
        {
            if (result.Success) return CreateSuccessResponse(result);
            return CreateFailureResponse(result);
        }

        private ApiResponse<UserLoginResponse> CreateSuccessResponse(Result<User?> result)
        {
            var response = new ApiResponse<UserLoginResponse>
            {
                Value = _mapper.Map<UserLoginResponse>(result.Data),
                StatusCode = 200
            };
            response.Value.Token = _jwtService.GenerateToken(result.Data ?? throw new ArgumentNullException(nameof(result), "Result value is null"));
            return response;
        }

        private ApiResponse<UserLoginResponse> CreateFailureResponse(Result<User?> result)
        {
            var response = new ApiResponse<UserLoginResponse>
            {
                StatusCode = 500
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
