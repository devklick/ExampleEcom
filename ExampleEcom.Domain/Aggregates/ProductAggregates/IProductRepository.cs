using ExampleEcom.Domain.Common;

namespace ExampleEcom.Domain.Aggregates.ProductAggregates
{
    public interface IProductRepository
    {
        Task<Result<List<Currency>>> GetCurrencies(string? search = null);
    }
}
