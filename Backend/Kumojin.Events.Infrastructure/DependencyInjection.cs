using Microsoft.Extensions.DependencyInjection;

using Kumojin.Events.Application.interfaces;
using Kumojin.Events.Infrastructure.Persistence;
using Kumojin.Events.Infrastructure.Services;
using Dapper;

namespace Kumojin.Events.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection  AddInfraStructure(this IServiceCollection  services)
    {
        services.AddSingleton<IDbContext, EventDbContext>();
        services.AddScoped<IEventRepository, EventRepository>();
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        return services;
    }
}
