using ExampleEcom.Api.Users.Commands;
using ExampleEcom.Api.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateUserRequest createUserRequest)
        {
            var command = new CreateUserCommand(createUserRequest);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
