using ExampleEcom.Api.Common;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExampleEcom.Api.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnon = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnon) return;

            if (context.HttpContext.Items["user"] is not User)
                context.Result = new JsonResult(ApiResponse.Unauthorized());
        }
    }
}
