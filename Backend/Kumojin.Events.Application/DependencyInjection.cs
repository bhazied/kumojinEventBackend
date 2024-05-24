using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Events.Application;

public static class DependencyInjection
{
    public static IServiceCollection  AddApplication(this IServiceCollection  services)
    {
        services.AddMediatR(config => {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(config => { config.AddMaps(Assembly.GetExecutingAssembly()); });
        return services;
    }

}
