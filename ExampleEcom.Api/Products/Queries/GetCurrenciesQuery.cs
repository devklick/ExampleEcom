using ExampleEcom.Api.Common;
using ExampleEcom.Api.Products.Requests;
using ExampleEcom.Api.Products.Responses;

namespace ExampleEcom.Api.Products.Queries
{
    public class GetCurrenciesQuery : MediatedRequest<GetCurrenciesRequest, GetCurrenciesResponse>
    {
        public GetCurrenciesQuery(GetCurrenciesRequest data) : base(data)
        { }
    }
}
