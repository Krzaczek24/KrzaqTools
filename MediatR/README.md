# Krzaq.MediatR
Library including simple implementation of MediatR

## v1.3.0
Added `CancellationToken` in `Send` and `Handle` methods, so that you can cancel requests and handlers.

## v1.2.0
Added `IRequestHandler<in TRequest>` interface, so that you can implement handlers for requests without response.
Changed call `Validate()` to `ValidateAsync()` in `RequestValidationBehavior` class, so that you can implement async validation.

## v1.1.3
Added `IRequestErrorsHandler` interface, if registered then it will be used to handle errors from MediatR requests, otherwise default behavior will be used (throwing exception).

## v1.1.2
Minor fixes

## v1.1.1
Added assembly argument to all IServiceCollection extension methods, so that you can specify which assembly to scan for MediatR handlers.
Default is `Assembly.GetCallingAssembly()`.

## v1.1.0
Updated `Krzaq.Tools.Reflection` dependency

## v1.0.0
Added first version of library
