using Microsoft.EntityFrameworkCore;
using WorldCities.Api.Middlewares.ICMPHealthCheck;
using WorldCities.Api.Options;
using WorldCities.Core.Domain.RepositoryContracts.CityImageRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;
using WorldCities.Core.ServiceContracts.CityServiceContracts;
using WorldCities.Core.Services.CityImageServices;
using WorldCities.Core.Services.CityServices;
using WorldCities.Infrastructure.ApplicationDatabaseContext;
using WorldCities.Infrastructure.Repositories.CitiesImagesRepository;
using WorldCities.Infrastructure.Repositories.CitiesRepository;
using WorldCities.Infrastructure.Repositories.CountriesRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICityRepository, CitiesRepository>();
builder.Services.AddScoped<ICountryRepository, CountriesRepository>();
builder.Services.AddScoped<ICityImageRepository, CitiesImagesRepository>();

builder.Services.AddScoped<ICitiesGetterService, CitiesGetterService>();
builder.Services.AddScoped<ICitiesAdderService, CitiesAdderService>();

builder.Services.AddScoped<ICityImageAdderService, CityImageAdderService>();
builder.Services.AddScoped<ICityImageGetterService, CityImageGetterService>();

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

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseHealthChecks(new PathString("/api/health"), new JsonHealthCheckOptions());

app.MapControllers();

app.Run();
