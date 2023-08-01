using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WorldCities.Api.Middlewares;
using WorldCities.Core;
using WorldCities.Core.Interfaces.Services;
using WorldCities.Core.Services;
using WorldCities.Domain.Constants;
using WorldCities.Domain.Identity;
using WorldCities.Infrastructure;
using WorldCities.Infrastructure.ApplicationDatabaseContext;
using WorldCities.Infrastructure.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddTransient<IJwtService, JwtService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddSignalR();

builder.Services.AddAppInfrastructure();

builder.Services.AddAppCore();

builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>(options =>
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

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = true,
            ValidAudience = builder.Configuration[ConfigurationConstants.JWT_AUDIENCE],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration[ConfigurationConstants.JWT_ISSUER],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(
                    builder.Configuration[ConfigurationConstants.JWT_KEY]!
                )
            )
        };
    });

builder.Services.AddAuthorization(options => { });

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.MapControllers();

app.MapHub<LikeHub>("/api/like-hub");

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();
