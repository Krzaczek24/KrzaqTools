using FluentValidation;
using Krzaq.MediatR.Implementations;
using Krzaq.MediatR.Interfaces;
using Krzaq.Tools.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Krzaq.MediatR
{
    public static class Extensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly? assembly = null)
        {
            var mediator = ReflectionToolbox.GetAllNonAbstractImplementingInterface<IMediator>(assembly ?? Assembly.GetCallingAssembly()).Except([typeof(Mediator)]).FirstOrDefault();
            return mediator is null
                ? services.AddScoped<IMediator, Mediator>()
                : services.AddScoped(sp => (IMediator)ActivatorUtilities.CreateInstance(sp, mediator));
        }

        public static IServiceCollection AddHandlers(this IServiceCollection services, Assembly? assembly = null)
        {
            foreach (Type handler in ReflectionToolbox.GetAllNonAbstractImplementingInterface<IRequestHandler>(assembly ?? Assembly.GetCallingAssembly()))
            {
                var handlerInterface = handler.GetInterface(typeof(IRequestHandler<,>).Name)
                    ?? throw new NullReferenceException($"No {nameof(IRequestHandler)} interface was found for {handler.Name} type");

                string requestName = handlerInterface.GenericTypeArguments[0].FullName!;

                services.AddKeyedSingleton($"{Mediator.HANDLER_PREFIX}_{requestName}", handlerInterface);
                services.AddTransient(handlerInterface, handler);
            }

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services, Assembly? assembly = null)
        {
            foreach (Type validator in ReflectionToolbox.GetAllNonAbstractImplementingInterface<IValidator>(assembly ?? Assembly.GetCallingAssembly()))
            {
                var validatorInterface = validator.GetInterface(typeof(IValidator<>).Name)
                    ?? throw new NullReferenceException($"No {nameof(IValidator)} interface was found for {validator.Name} type");

                string requestName = validatorInterface.GenericTypeArguments[0].FullName!;

                services.AddKeyedSingleton($"{Mediator.VALIDATOR_PREFIX}_{requestName}", validatorInterface);
                services.AddTransient(validatorInterface, validator);
            }

            return services;
        }
    }
}
