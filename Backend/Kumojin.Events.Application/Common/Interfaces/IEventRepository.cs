using Kumojin.Events.Model.Entities.Event;

namespace Kumojin.Events.Application.interfaces;
public interface IEventRepository
{
    public Task<IEnumerable<Event>> GetAllAsync();
    public Task<int> AddAsync(Event @event);
}
