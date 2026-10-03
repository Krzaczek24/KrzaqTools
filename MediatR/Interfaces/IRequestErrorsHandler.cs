using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Krzaq.MediatR.Interfaces
{
    public interface IRequestErrorsHandler
    {
        Task<Exception> Handle(IReadOnlyCollection<ValidationFailure> errors, CancellationToken cancellationToken = default);
    }
}
