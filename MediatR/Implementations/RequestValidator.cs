using FluentValidation;
using Krzaq.MediatR.Interfaces;

namespace Krzaq.MediatR.Implementations
{
    public abstract class RequestValidator<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
        where TRequest : IRequest
    {
    }
}
