using System.ComponentModel.DataAnnotations;

namespace ExampleEcom.Api.Products.Requests
{
    public class GetCurrenciesRequest
    {
        public string? Search { get; set; } = default!;
    }
}
