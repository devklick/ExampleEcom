using ExampleEcom.Api.Products.Responses;
using ExampleEcom.Domain.Aggregates.ProductAggregates;

namespace ExampleEcom.Api.Products.Mappings
{
    public class ProductMappingProfile : AutoMapper.Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Currency, GetCurrenciesResponseItem>();
        }
    }
}
