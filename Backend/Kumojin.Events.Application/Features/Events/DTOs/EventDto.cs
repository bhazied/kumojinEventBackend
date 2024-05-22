using System.ComponentModel;

namespace Kumojin.Events.Application;

[Description("Events")]
public class EventDto
{
    [Description("Id")] public Guid Id {get; set;}
    [Description("Name")] public string Name {get; set;}
    [Description("Description")] public string Description {get; init;}
    [Description("Program")] public string Program {get; init;}
    [Description("Location")] public string Location {get; init;}
    [Description("Start Date")] public DateTime StartDate {get; init;}
    [Description("End Date")] public DateTime EndDate {get; init;}
}
