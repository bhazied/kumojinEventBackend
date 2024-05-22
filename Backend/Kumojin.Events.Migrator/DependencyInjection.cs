using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Events.Migrator;
public static class DependencyInjection
{
    public static IServiceCollection  AddMigrator(this IServiceCollection  services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(rb => 
                rb.AddSQLite()
                .WithGlobalConnectionString(configuration.GetConnectionString("KumojinEventConnection"))
                .ScanIn(typeof(DependencyInjection).Assembly).For.Migrations()
                ).AddLogging(lb => 
                    lb.AddFluentMigratorConsole()
                )
                .Configure<RunnerOptions>(conf => 
                    conf.Tags = new []{"Development"}
                )
                .BuildServiceProvider();
        return services;
    }
}
