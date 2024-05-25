using AutoMapper;
using Kumojin.Events.Model.Entities.Event;
using MediatR;

namespace Kumojin.Events.Application;

public class CreateEventCommand(
    string Name, 
    string Description,
    string Program,
    string Location,
    string TimeZone,
    DateTime StartDate,
    DateTime EndDate
    ) : IRequest<Result<int>>
{
    public string Name {get; init;} = Name;
    public string Description {get; init;} = Description;
    public string Program {get; init;} = Program;
    public string Location {get; init;} = Location;
    public string Timezone {get; init;} = TimeZone;
    public DateTime StartDate {get; init;} = StartDate;
    public DateTime EndDate {get; init;} = EndDate;

    private class Mapping: Profile 
    {
        public Mapping()
        {
            CreateMap<CreateEventCommand, Event>(MemberList.None).ReverseMap();
        }
    }
}
