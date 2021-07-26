using MediatR;

namespace OneNet.Base.Application
{
    public class Request<TContent, TResponse> : IRequest<TResponse>
    {
        public TContent RequestContent { get; set; }
    }
}