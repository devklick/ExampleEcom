using ExampleEcom.Domain.Aggregates.ProductAggregates;
using ExampleEcom.Domain.Common;
using ExampleEcom.Domain.Persistence;

namespace ExampleEcom.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IAppDbContext _context;

        public ProductRepository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Result<List<Currency>>> GetCurrencies(string? search = null)
        {
            var result = new Result<List<Currency>>
            {
                Success = true,
            };

            var currencies = _context.Currencies.AsQueryable();
            var searchLower = search?.ToLower();

            if (!string.IsNullOrWhiteSpace(searchLower))
            {
                currencies.Where(
                    c => c.Name.ToLower().Contains(searchLower)
                    || c.Code.ToLower().Contains(searchLower)
                    || c.Symbol.ToLower().Contains(searchLower));
            }

            result.Data = currencies.ToList();

            return await Task.FromResult(result);
        }
    }
}
