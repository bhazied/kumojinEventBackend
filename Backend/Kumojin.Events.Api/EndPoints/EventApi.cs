using Microsoft.AspNetCore.Http.HttpResults;

namespace Kumojin.Events.Api.EndPoints;

public static class EventApi
{
    public static void MapEventEndPoints(this WebApplication app)
    {
        app.MapGet("events", () => {
            return Results.Ok("Event List");
        }).WithName("EventList")
          .WithDescription("Return All Events From database");
    }

}
