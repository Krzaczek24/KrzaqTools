using FluentValidation.Results;
using Krzaq.MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krzaq.MediatR.Implementations
{
    public interface IMediator
    {
        public ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }

    public sealed class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        internal const string VALIDATOR_PREFIX = "VALIDATOR";
        internal const string HANDLER_PREFIX = "HANDLER";

        public async ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            string requestName = request.GetType().FullName!;

            var validatorInterface = serviceProvider.GetKeyedService<Type>($"{VALIDATOR_PREFIX}_{requestName}");
            if (validatorInterface is not null)
            {
                var validator = (IRequestValidator)serviceProvider.GetRequiredService(validatorInterface);
                var result = validator.Validate(request);
                if (!result.IsValid)
                {
                    var errorsHandler = serviceProvider.GetService<IRequestErrorsHandler>();
                    if (errorsHandler is not null)
                    {
                        throw await errorsHandler.Handle(result.Errors);
                    }
                    throw HandleInvalidValidation(result.Errors);
                }
            }

            var handlerInterface = serviceProvider.GetRequiredKeyedService<Type>($"{HANDLER_PREFIX}_{requestName}");
            var handler = (IRequestHandler)serviceProvider.GetRequiredService(handlerInterface);
            return (TResponse)await handler.Handle(request);
        }

        private static InvalidOperationException HandleInvalidValidation(IReadOnlyCollection<ValidationFailure> errors)
        {
            string stringifiedErrors = string.Join("\n", errors.Select(Convert));
            return new InvalidOperationException($"Validation failures:\n{stringifiedErrors}");
            static string Convert(ValidationFailure failure) => $"{failure.PropertyName}: {failure.ErrorMessage}";
        }
    }
}
