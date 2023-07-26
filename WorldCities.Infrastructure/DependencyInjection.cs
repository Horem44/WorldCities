using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorldCities.Core.Commands.Cities.AddCity;
using WorldCities.Core.Interfaces.Repositories;
using WorldCities.Infrastructure.Repositories;

namespace WorldCities.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppInfrastructure(this IServiceCollection services)
        {
            var appCoreassembly = Assembly.GetAssembly(typeof(AddCityCommand))!;

            return services
                .AddScoped<ICityRepository, CitiesRepository>()
                .AddScoped<ICountryRepository, CountriesRepository>()
                .AddScoped<ICityImageRepository, CitiesImagesRepository>()
                .AddScoped<ILikeRepository, LikeRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddAutoMapper(appCoreassembly)
                .AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(appCoreassembly));
        }
    }
}
