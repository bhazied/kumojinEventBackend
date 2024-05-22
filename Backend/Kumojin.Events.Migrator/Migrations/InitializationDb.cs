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
        if(!Schema.Table("Events").Exists())
        {
            Create.Table("Events")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(32).NotNullable().Unique()
            .WithColumn("Description").AsString(255).NotNullable()
            .WithColumn("Program").AsString()
            .WithColumn("Location").AsString()
            .WithColumn("Start_Date").AsDateTime().NotNullable()
            .WithColumn("End_Date").AsDateTime().NotNullable();
        }
    }
}
