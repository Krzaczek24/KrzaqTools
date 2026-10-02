using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Krzaq.MediatR.Interfaces
{
    public interface IRequestValidator
    {
        ValidationResult Validate(object request);
        Task<ValidationResult> ValidateAsync(object request, CancellationToken cancellationToken = default);
    }

    public interface IRequestValidator<in TRequest> : IRequestValidator
        where TRequest : IRequest
    {
        ValidationResult Validate(TRequest request);
        ValidationResult IRequestValidator.Validate(object request) => Validate((TRequest)request);

        Task<ValidationResult> ValidateAsync(TRequest request, CancellationToken cancellationToken = default);
        Task<ValidationResult> IRequestValidator.ValidateAsync(object request, CancellationToken cancellationToken) => ValidateAsync((TRequest)request, cancellationToken);
    }
}
