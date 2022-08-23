using AutoMapper;
using ExampleEcom.Api.Common;
using ExampleEcom.Api.Products.Queries;
using ExampleEcom.Api.Products.Responses;
using ExampleEcom.Domain.Aggregates.ProductAggregates;
using MediatR;

namespace ExampleEcom.Api.Products.Handlers
{
    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, ApiResponse<GetCurrenciesResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetCurrenciesQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GetCurrenciesResponse>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var currencies = await _productRepository.GetCurrencies(request.Data.Search);

            var response = new ApiResponse<GetCurrenciesResponse>
            {
                StatusCode = currencies.Success ? 200 : 500,
                Value = currencies.Data == null ? null : new GetCurrenciesResponse
                {
                    Currencies = _mapper.Map<List<Currency>, List<GetCurrenciesResponseItem>>(currencies.Data),
                }
            };

            if (!currencies.Success)
            {
                response.AddError("UnknownError", "An unknown error occurred while getting the currencies");
            }

            return response;
        }
    }
}
