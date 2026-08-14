using FluentValidation;
using Krzaq.Tools.MediatR.Interfaces;

namespace Krzaq.Tools.MediatR.Implementations
{
    public abstract class RequestValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
        where TRequest : IRequest
    {
    }
}
