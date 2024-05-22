using Microsoft.AspNetCore.Builder;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Kumojin.Events.Infrastructure;

public static class EventDbContextInitializer
{

    public static async Task InitDatabaseAsync(this WebApplication app)
    {
        using(var scope = app.Services.CreateScope())
        {
            var migratorRunner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            migratorRunner.MigrateUp();
         }
    }
}
