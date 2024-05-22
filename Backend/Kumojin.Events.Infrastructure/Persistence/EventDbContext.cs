using System.Data;
using Kumojin.Events.Application.interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Kumojin.Events.Infrastructure.Persistence;

public class EventDbContext : IDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public EventDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("KumojinEventConnection");
    }

    public IDbConnection CreateConnection() => new SqliteConnection(_connectionString);

}
