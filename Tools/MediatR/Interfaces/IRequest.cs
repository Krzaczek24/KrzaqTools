namespace Krzaq.Tools.MediatR.Interfaces
{
    public interface IRequest { }
    public interface IRequest<out TResponse> : IRequest { }
}
