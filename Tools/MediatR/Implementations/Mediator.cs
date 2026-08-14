using FluentValidation.Results;
using Krzaq.Tools.MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Krzaq.Tools.MediatR.Implementations
{
    public interface IMediator
    {
        public ValueTask<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }

    public abstract class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        private const string VALIDATOR_PREFIX = "VALIDATOR";
        private const string HANDLER_PREFIX = "HANDLER";

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
                    var exception = HandleInvalidValidation(result.Errors);
                    throw exception;
                }
            }

            var handlerInterface = serviceProvider.GetRequiredKeyedService<Type>($"{HANDLER_PREFIX}_{requestName}");
            var handler = (IRequestHandler)serviceProvider.GetRequiredService(handlerInterface);
            return (TResponse)await handler.Handle(request);
        }

        protected abstract Exception HandleInvalidValidation(List<ValidationFailure> errors);
    }
}
