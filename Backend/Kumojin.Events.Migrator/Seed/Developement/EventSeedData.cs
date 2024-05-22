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
            .RuleFor(e => e.Id , _ => Guid.NewGuid())
            .RuleFor(e => e.Name, f => f.Name.LastName())
            .RuleFor(e => e.Description, f => f.Lorem.Sentence())
            .RuleFor(e => e.Program, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Location, f => f.Address.Country())
            .RuleFor( e => e.StartDate, f => f.Date.Between(new DateTime(2024, 1, 1), new DateTime(2025, 12, 31)));
            // .RuleFor( e => e.EndDate, f => f.Date.Between(new DateTime(2024, 12, 31), new DateTime(2025, 12, 31)));
            var FakeEvents = faker.Generate(15);
            Random rnd = new();
        foreach(var FakeEvent in FakeEvents){
            Insert.IntoTable("Events").Row(
                new {
                    Id = FakeEvent.Id,
                    Name = FakeEvent.Name,
                    Description = FakeEvent.Description,
                    Program = FakeEvent.Program,
                    location = FakeEvent.Location,
                    Start_Date = FakeEvent.StartDate,
                    End_Date = FakeEvent.StartDate.AddDays(rnd.Next(1,15))
                }
            );
        } 
    }

    public override void Down()
    {
       Delete.FromTable("Events").AllRows();
    }
}
