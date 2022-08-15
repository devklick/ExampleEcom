using ExampleEcom.Api.Accounts.Commands;
using ExampleEcom.Api.Accounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;
        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateAccountRequest createAccountRequest)
        {
            var command = new CreateAccountCommand(createAccountRequest);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}