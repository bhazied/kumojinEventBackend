
using System.Data;
using Dapper;
using Kumojin.Events.Application.interfaces;
using Kumojin.Events.Infrastructure.Persistence;
using Kumojin.Events.Model.Entities.Event;

namespace Kumojin.Events.Infrastructure.Services;

public class EventRepository : IEventRepository
{
    public readonly IDbContext _context;
    public readonly IDbConnection _connection;
    public EventRepository(IDbContext context)
    {
        _context = context;
        _connection = _context.CreateConnection();
    }
    public async Task<int> AddAsync(Event @event)
    {
        int affectedRows = 0;
        try
        {
        affectedRows = await _connection.ExecuteAsync(Constants.AddNewEvent, @event);
        }catch(Exception ex)
        {
            
        }
       return affectedRows;
    }

    public async Task<IEnumerable<Event>> GetAllAsync()
    {
        IEnumerable<Event> result = null;
        try
        {
            result = await _connection.QueryAsync<Event>(Constants.GetAllEvents);
        }catch(Exception ex){}
        return result;
    }
}
