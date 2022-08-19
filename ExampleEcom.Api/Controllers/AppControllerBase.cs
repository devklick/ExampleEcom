using ExampleEcom.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace ExampleEcom.Api.Controllers
{
    public class AppControllerBase : ControllerBase
    {
        protected ActionResult<ApiResponse<T>> CreateApiResponse<T>(ApiResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
