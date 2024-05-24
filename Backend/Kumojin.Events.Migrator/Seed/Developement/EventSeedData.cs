using Bogus;
using FluentMigrator;
using Kumojin.Events.Model.Entities.Event;
namespace Kumojin.Events.Migrator;

[Tags("Development")]
[Migration(0002)]
public class EventSeedData : Migration
{
    public override void Up()
    {
         var faker = new Faker<Event>(locale: "fr_CA")
            .RuleFor(e => e.Name, f => f.Company.CompanyName())
            .RuleFor(e => e.Description, f => f.Lorem.Sentence())
            .RuleFor(e => e.Program, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Location, f => f.Address.FullAddress())
            .RuleFor( e => e.Timezone, f => GetTimeZone(f))
            .RuleFor( e => e.StartDate, f => f.Date.Between(new DateTime(2024, 1, 1), new DateTime(2025, 12, 31)));
            
            var FakeEvents = faker.Generate(15);
            Random rnd = new();
        foreach(var FakeEvent in FakeEvents){
            Insert.IntoTable("Events").Row(
                new {
                    event_id = Guid.NewGuid(),
                    name = $"Event for Company : {FakeEvent.Name}",
                    description = FakeEvent.Description,
                    program = FakeEvent.Program,
                    location = FakeEvent.Location,
                    start_date = FakeEvent.StartDate,
                    timezone = FakeEvent.Timezone,
                    end_date = FakeEvent.StartDate.AddDays(rnd.Next(1,3))
                }
            );
        } 
    }

    public override void Down()
    {
       Delete.FromTable("Events").AllRows();
    }

    private string GetTimeZone(Faker faker)
    {
        string[] timezones = [
            "GMT-07:00", 
            "GMT-09:00", 
            "GMT-03:00", 
            "GMT-04:00", 
            "GMT+09:00", 
            "GMT-10:00", 
            "GMT", 
            "UTC+01:00", 
            "UTC+01:00", 
            "UTC+02:00", 
            "UTC+03:00", 
            "UTC+04:00", 
            "GMT-11:00"
            ];
        var random = faker.Random.Int(0, timezones.Count()-1);
        return timezones[random];
    }
}
