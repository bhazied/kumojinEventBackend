using AutoMapper;
using Kumojin.Events.Model.Entities.Event;

namespace Kumojin.Events.Application;

public class EventMapping : Profile
{
    public EventMapping()
    {
         CreateMap<EventDto, Event>().ReverseMap();
    }
}
