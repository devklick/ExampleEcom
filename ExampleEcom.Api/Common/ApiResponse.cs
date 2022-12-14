using System.Linq.Expressions;

namespace ExampleEcom.Api.Common
{
    public class ApiResponse : ApiResponse<object>
    { }
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Value { get; set; }
        public Dictionary<string, HashSet<string>>? Errors { get; set; }

        public void AddError(string code, string message)
        {
            if (Errors == null) Errors = new Dictionary<string, HashSet<string>>();
            if (Errors.ContainsKey(code)) Errors[code].Add(message);
            else Errors.Add(code, new HashSet<string> { message });
        }

        // public void AddModelError(Expression<Func<T, string>> nameExp, string message)
        // {
        //     var paramType = nameExp.Parameters[0].Type;
        //     var name = paramType.GetMember(((MemberExpression)nameExp.Body).Member.Name)[0].Name;
        //     AddError(name, message);
        // }

        public static ApiResponse<object> Unauthorized(object? value = null)
        {
            var response = new ApiResponse<object>
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Value = value
            };
            response.AddError("Unauthorized", "You must be logged in to access this resource");
            return response;
        }
    }
}
