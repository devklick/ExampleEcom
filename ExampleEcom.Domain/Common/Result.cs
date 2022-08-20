namespace ExampleEcom.Domain.Common
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<ErrorDetail>? Errors { get; set; }

        public void AddError(string code, string description)
        {
            if (Errors == null) Errors = new List<ErrorDetail>();
            Errors.Add(new ErrorDetail(code, description));
        }
    }
}
