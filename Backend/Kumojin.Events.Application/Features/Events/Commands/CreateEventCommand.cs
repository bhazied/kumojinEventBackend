using AutoMapper;
using Kumojin.Events.Model.Entities.Event;
using MediatR;

namespace Kumojin.Events.Application;

public class CreateEventCommand : IRequest<Result<int>>
{
    public string Name {get; init;}
    public string Description {get; init;}
    public string Program {get; init;}
    public string Location {get; init;}
    public string Timezone {get; init;}
    public DateTime StartDate {get; init;}
    public DateTime EndDate {get; init;}

    private class Mapping: Profile 
    {
        public Mapping()
        {
            CreateMap<CreateEventCommand, Event>(MemberList.None).ReverseMap();
        }
    }
}
