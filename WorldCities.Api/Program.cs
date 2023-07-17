using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WorldCities.Api.Middlewares.ICMPHealthCheck;
using WorldCities.Api.Options;
using WorldCities.Core.Domain.RepositoryContracts.CityImageRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CityRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.CountryRepositoryContract;
using WorldCities.Core.Domain.RepositoryContracts.LikeRepositoryContract;
using WorldCities.Core.Identity;
using WorldCities.Core.ServiceContracts.Auth;
using WorldCities.Core.ServiceContracts.CityImageServiceContracts;
using WorldCities.Core.ServiceContracts.CityServiceContracts;
using WorldCities.Core.ServiceContracts.CountryServiceContracts;
using WorldCities.Core.ServiceContracts.Like;
using WorldCities.Core.ServiceContracts.User;
using WorldCities.Core.Services.Auth;
using WorldCities.Core.Services.CityImageServices;
using WorldCities.Core.Services.CityServices;
using WorldCities.Core.Services.CountryServices;
using WorldCities.Core.Services.LikeService;
using WorldCities.Core.Services.User;
using WorldCities.Infrastructure.ApplicationDatabaseContext;
using WorldCities.Infrastructure.Hubs;
using WorldCities.Infrastructure.Repositories.CitiesImagesRepository;
using WorldCities.Infrastructure.Repositories.CitiesRepository;
using WorldCities.Infrastructure.Repositories.CountriesRepository;
using WorldCities.Infrastructure.Repositories.LikeRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<ICityRepository, CitiesRepository>();
builder.Services.AddScoped<ICountryRepository, CountriesRepository>();
builder.Services.AddScoped<ICityImageRepository, CitiesImagesRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();

builder.Services.AddScoped<ICitiesGetterService, CitiesGetterService>();
builder.Services.AddScoped<ICitiesAdderService, CitiesAdderService>();

builder.Services.AddScoped<ICityImageAdderService, CityImageAdderService>();
builder.Services.AddScoped<ICityImageGetterService, CityImageGetterService>();

builder.Services.AddScoped<ICountryGetterService, CountryGetterService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ILikeService, LikeService>();

builder.Services.AddTransient<IJwtService, JwtService>();

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

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
    .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization(options =>
{

});

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseHealthChecks(new PathString("/api/health"), new JsonHealthCheckOptions());

app.MapControllers();

app.Run();
