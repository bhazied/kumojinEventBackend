using Kumojin.Events.Api.EndPoints;
using Kumojin.Events.Migrator;
using Kumojin.Events.Application;
using Kumojin.Events.Infrastructure;
using Kumojin.Events.Api.Builder.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMigrator(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfraStructure();
builder.Services.AddCorsPolicies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.InitDatabaseAsync();
}
app.UseCors("EventFrontedPolicy");
app.UseHttpsRedirection();
app.MapEventEndPoints();
app.Run();


