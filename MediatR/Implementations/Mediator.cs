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

    public class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        public const string VALIDATOR_PREFIX = "VALIDATOR";
        public const string HANDLER_PREFIX = "HANDLER";

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
                    throw HandleInvalidValidation(result.Errors);
                }
            }

            var handlerInterface = serviceProvider.GetRequiredKeyedService<Type>($"{HANDLER_PREFIX}_{requestName}");
            var handler = (IRequestHandler)serviceProvider.GetRequiredService(handlerInterface);
            return (TResponse)await handler.Handle(request);
        }

        protected virtual Exception HandleInvalidValidation(List<ValidationFailure> errors)
        {
            string stringifiedErrors = string.Join("\n", errors.Select(Convert));
            return new InvalidOperationException($"Validation failures:\n{stringifiedErrors}");
            static string Convert(ValidationFailure failure) => $"";
        }
    }
}
