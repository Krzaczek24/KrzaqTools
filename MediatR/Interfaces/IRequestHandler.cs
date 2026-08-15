using System.Threading.Tasks;

namespace Krzaq.MediatR.Interfaces
{
    public interface IRequestHandler
    {
        ValueTask<object> Handle(object request);
    }

    public interface IRequestHandler<in TRequest, TResponse> : IRequestHandler
        where TRequest : IRequest<TResponse>
    {
        ValueTask<TResponse> Handle(TRequest request);
        async ValueTask<object> IRequestHandler.Handle(object request) => (await Handle((TRequest)request))!;
    }
}
