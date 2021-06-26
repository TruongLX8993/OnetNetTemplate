using MediatR;

namespace OneNet.Core.Application
{
    public  class Request<TContent,TResponse> : IRequest<TResponse>
    {
       public TContent RequestContent { get; set; }
        
    }
}