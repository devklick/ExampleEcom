using ExampleEcom.Api.Authorization;
using ExampleEcom.Api.Common;
using ExampleEcom.Api.Products.Queries;
using ExampleEcom.Api.Products.Requests;
using ExampleEcom.Api.Products.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    [Authorize]
    [ApiController, Route("[controller]")]
    public class ProductController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("currency"), AllowAnonymous]
        public async Task<ActionResult<ApiResponse<GetCurrenciesResponse>>> GetCurrencies([FromQuery] GetCurrenciesRequest request)
        {
            var command = new GetCurrenciesQuery(request);
            var response = await _mediator.Send(command);
            return CreateObjectResult(response);
        }
    }
}
