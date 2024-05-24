using Kumojin.Events.Model.Common;

namespace Kumojin.Events.Model.Entities.Event;

public sealed class Event : BaseEntity
{
    public string EventId {get; set;}
    public string Name {get; init;}
    public string Description {get; init;}
    public string Program {get; init;}
    public string Location {get; init;}
    public string Timezone {get; init;}
    public DateTime StartDate {get; init;}
    public DateTime EndDate {get; init;}

}

