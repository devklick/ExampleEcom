using System.Reflection;
using ExampleEcom.Domain.Aggregates.UserAggregates;
using ExampleEcom.Domain.Configuration;
using ExampleEcom.Domain.Persistence;
using ExampleEcom.Domain.Repository;
using ExampleEcom.Infrastructure.Crypto.Jwt;
using ExampleEcom.Api.Middleware;
using ExampleEcom.Infrastructure.Persistence;
using ExampleEcom.Infrastructure.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ExampleEcom.Domain.Aggregates.ProductAggregates;
using ExampleEcom.Infrastructure.Repositories;

namespace ExampleEcom.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var app = CreateAppBuilder(args).Build();
        AddMiddlewares(app);
        app.Run();
    }

    private static WebApplicationBuilder CreateAppBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        AddIdentity(builder);
        AddDbContext(builder);
        AddAuthorization(builder);
        AddSwagger(builder);
        AddAutoMapper(builder);
        AddMediatR(builder);
        AddRepositories(builder);
        AddRouteOptions(builder);
        AddJwt(builder);

        return builder;
    }

    private static void AddJwt(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IJwtService, JwtService>();
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
    }

    private static void AddRouteOptions(WebApplicationBuilder builder)
    {
        builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    }

    private static void AddMediatR(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
    }

    private static void AddAuthorization(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();
    }

    private static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    private static void AddDbContext(WebApplicationBuilder builder)
    {
        var connections = builder.Configuration.GetSection(nameof(DatabaseConnections)).Get<DatabaseConnections>();
        var defaultConnection = connections.GetConnectionString("Default");

        if (string.IsNullOrEmpty(defaultConnection))
        {
            throw new InvalidOperationException("A default connection string is required");
        }
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(defaultConnection);
        });
        builder.Services.AddScoped<IAppDbContext>(p => p.GetRequiredService<AppDbContext>());
    }

    private static void AddIdentity(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<User, Role>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequiredLength = 9;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
        })
        .AddEntityFrameworkStores<AppDbContext>();
    }

    private static void AddAutoMapper(WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(Program));
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IProductRepository, ProductRepository>();
    }

    private static WebApplication AddMiddlewares(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseMiddleware<UserAuthorizationMiddleware>();

        app.MapControllers();

        return app;
    }
}
