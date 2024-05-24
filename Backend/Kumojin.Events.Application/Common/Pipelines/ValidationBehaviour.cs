using System.Reflection;
using FluentValidation;
using Kumojin.Events.Application.Common.Interfaces;
using MediatR;

namespace Kumojin.Events.Application;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );
            var failures = validationResult.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();
            if(failures.Any())
            {
                var errors = failures.Select(f => f.ErrorMessage).ToArray();
                #pragma warning disable CS8603
                #pragma warning disable CS8602
                #pragma warning disable CS8600
                var result = (typeof(Result<>).MakeGenericType(typeof(TResponse).GetGenericArguments())
                .GetMethod("Failure", BindingFlags.Public | BindingFlags.Static).Invoke(null, new object?[] { errors }));
                return   (TResponse)result;
            } 
        }
        return await next();
    }
}
