using Kumojin.Events.Application.interfaces;
using Kumojin.Events.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Events.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection  AddInfraStructure(this IServiceCollection  services)
    {
        services.AddSingleton<IDbContext, EventDbContext>();
        return services;
    }
}
