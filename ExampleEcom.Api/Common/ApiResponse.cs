namespace ExampleEcom.Api.Common
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Value { get; set; }
        public Dictionary<string, HashSet<string>>? Errors { get; set; }
    }
}
