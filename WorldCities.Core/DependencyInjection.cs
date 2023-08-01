using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using WorldCities.Core.Accessors;
using WorldCities.Core.Commands.Cities.AddCity;
using WorldCities.Core.Interfaces.Accessors;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Core.Services;

namespace WorldCities.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppCore(this IServiceCollection services) =>
            services
                .AddScoped<IJwtService, JwtService>()
                .AddScoped<IUserAccessor, UserAccessor>()
                .AddValidatorsFromAssemblyContaining<AddCityCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
    }
}
