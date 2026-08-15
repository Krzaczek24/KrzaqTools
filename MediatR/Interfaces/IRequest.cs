namespace Krzaq.MediatR.Interfaces
{
    public interface IRequest { }
    public interface IRequest<out TResponse> : IRequest { }
}
