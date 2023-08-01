using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorldCities.Core.Commands.Cities.AddCity;
using WorldCities.Core.Interfaces.Events;
using WorldCities.Core.Interfaces.Hubs;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Infrastructure.ApplicationDatabaseContext;
using WorldCities.Infrastructure.Repositories;
using WorldCities.Infrastructure.Services;

namespace WorldCities.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection services)
        {
            var appCoreassembly = Assembly.GetAssembly(typeof(AddCityCommand))!;

            return services
                .AddHttpContextAccessor()
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
                .AddSingleton<ILikeHubClientService, LikeHubClientService>()
                .AddScoped<ICityRepository, CitiesRepository>()
                .AddScoped<ICountryRepository, CountriesRepository>()
                .AddScoped<ICityImageRepository, CitiesImagesRepository>()
                .AddScoped<ILikeRepository, LikeRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddTransient<IEventPublisher, EventPublisher>()
                .AddAutoMapper(appCoreassembly)
                .AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(appCoreassembly));
        }
    }
}
