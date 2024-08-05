using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () =>
{
    if (Random.Shared.Next(4) == 1)
    {
        throw new Exception("Random exception");
    }
    return "Hello World!";
});

app.Run();
