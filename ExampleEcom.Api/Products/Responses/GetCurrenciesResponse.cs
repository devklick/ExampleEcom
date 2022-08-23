using ExampleEcom.Domain.Aggregates.ProductAggregates;

namespace ExampleEcom.Api.Products.Responses
{
    public class GetCurrenciesResponseItem
    {
        public string Name { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Symbol { get; set; } = default!;
        public CurrencySymbolOrientation SymbolOrientation { get; set; }
        public bool SpacedSymbol { get; set; }
    }
    public class GetCurrenciesResponse
    {
        public List<GetCurrenciesResponseItem> Currencies { get; set; } = new List<GetCurrenciesResponseItem>();
    }
}
