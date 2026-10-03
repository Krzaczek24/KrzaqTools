using System.Threading;
using System.Threading.Tasks;

namespace Krzaq.MediatR.Interfaces
{
    public interface IRequestHandler
    {
        ValueTask<object> Handle(object request, CancellationToken cancellationToken = default);
    }

    public interface IRequestHandler<in TRequest, TResponse> : IRequestHandler
        where TRequest : IRequest<TResponse>
    {
        ValueTask<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
        async ValueTask<object> IRequestHandler.Handle(object request, CancellationToken cancellationToken)
        {
            var response = await Handle((TRequest)request, cancellationToken);
            return response!;
        }
    }

    public interface IRequestHandler<in TRequest> : IRequestHandler
        where TRequest : IRequest
    {
        ValueTask Handle(TRequest request, CancellationToken cancellationToken = default);
        async ValueTask<object> IRequestHandler.Handle(object request, CancellationToken cancellationToken)
        {
            await Handle((TRequest)request, cancellationToken);
            return null!;
        }
    }
}
