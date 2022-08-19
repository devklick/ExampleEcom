namespace ExampleEcom.Domain.Common
{
    public class ErrorDetail
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public ErrorDetail(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
