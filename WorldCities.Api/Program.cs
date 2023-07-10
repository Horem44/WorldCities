using WorldCities.Api.Middlewares.ICMPHealthCheck;
using WorldCities.Api.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks().AddICMPHealthCheck(300, "127.0.0.1");
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseHealthChecks(new PathString("/api/health"), new JsonHealthCheckOptions());

app.MapControllers();

app.Run();
