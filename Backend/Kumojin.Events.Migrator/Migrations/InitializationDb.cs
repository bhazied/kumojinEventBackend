using FluentMigrator;

namespace Kumojin.Events.Migrator;
[Migration(0001)]
public class InitializationDb : Migration
{
    public override void Down()
    {
        if(Schema.Table("Events").Exists())
        {
            Delete.Table("Events");
        }
    }

    public override void Up()
    {
        if(!Schema.Table("events").Exists())
        {
            Create.Table("events")
            .WithColumn("event_id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("name").AsString(32).NotNullable().Unique()
            .WithColumn("description").AsString(255).NotNullable()
            .WithColumn("program").AsString()
            .WithColumn("location").AsString()
            .WithColumn("start_date").AsDateTime().NotNullable()
            .WithColumn("timezone").AsDateTime().NotNullable()
            .WithColumn("end_date").AsDateTime().NotNullable();
        }
    }
}
