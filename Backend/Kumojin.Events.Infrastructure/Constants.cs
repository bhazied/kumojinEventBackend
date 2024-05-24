namespace Kumojin.Events.Infrastructure;

public static class Constants
{
    public const string EventTable = "events";
    public const string GetAllEvents = "SELECT * FROM events";

    public const string AddNewEvent = "INSERT INTO events " +
        "(event_id, name, description, program, location, timezone, start_date, end_date)" + 
        "VALUES(@EventId, @Name, @Description, @Program, @Location, @Timezone, @StartDate, @EndDate)";

}
