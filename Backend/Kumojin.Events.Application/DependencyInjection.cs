using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Events.Application;

public static class DependencyInjection
{
    public static IServiceCollection  AddApplication(this IServiceCollection  services)
    {
        services.AddMediatR(config => {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(config => { config.AddMaps(Assembly.GetExecutingAssembly()); });
        return services;
    }

}
