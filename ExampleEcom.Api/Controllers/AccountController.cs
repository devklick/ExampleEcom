using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post()
        {
            return await Task.FromResult("Hello from POST account");
        }
    }
}