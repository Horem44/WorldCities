using Microsoft.EntityFrameworkCore;
using WorldCities.Api.Middlewares.ICMPHealthCheck;
using WorldCities.Api.Options;
using WorldCities.Infrastructure.ApplicationDatabaseContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddHealthChecks().AddICMPHealthCheck(300, "127.0.0.1");
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseHealthChecks(new PathString("/api/health"), new JsonHealthCheckOptions());

app.MapControllers();

app.Run();
