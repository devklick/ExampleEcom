using MediatR;

namespace ExampleEcom.Api.Common
{
    public class MediatedRequest<TRequest, TResponse> : IRequest<ApiResponse<TResponse>>
    {
        public TRequest Data { get; }

        public MediatedRequest(TRequest data)
        {
            Data = data;
        }
    }
}
