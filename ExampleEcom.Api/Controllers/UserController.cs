using ExampleEcom.Api.Common;
using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Requests;
using ExampleEcom.Api.Users.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class UserController : AppControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<CreateUserResponse>>> Post([FromBody] CreateUserRequest createUserRequest)
        {
            var command = new CreateUserCommand(createUserRequest);
            var response = await _mediator.Send(command);
            return CreateApiResponse(response);
        }
    }
}
