namespace ExampleEcom.Domain.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<ErrorDetail>? Errors { get; set; }
    }
}
