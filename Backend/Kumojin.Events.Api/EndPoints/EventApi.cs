using MediatR;
using Kumojin.Events.Application;
using Microsoft.AspNetCore.Mvc;
namespace Kumojin.Events.Api.EndPoints;

public static class EventApi
{
    public static void MapEventEndPoints(this WebApplication app)
    {
        app.MapGet("events", async (IMediator mediator) => {
            var events = await mediator.Send(new GetAllEventQuery());
            return Results.Ok(events);
        }).WithName("EventList")
          .WithDescription("Return All Events From database")
          .WithOpenApi();

        app.MapPost("events", async(IMediator mediator, HttpRequest request) => {
             var @event = await request.ReadFromJsonAsync<CreateEventCommand>();
             Result<int> result = await mediator.Send(@event);
             return Results.Ok(result);
        }).WithName("AddEvent")
          .WithDescription("Add a new Event")
          .WithOpenApi();
    }

}
