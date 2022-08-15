using ExampleEcom.Repository.Configuration;
using ExampleEcom.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExampleEcom.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        AddDbContext(builder);
        AddIdentity(builder);

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
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
            options.UseSnakeCaseNamingConvention();
        });
    }

    private static void AddIdentity(WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.Password.RequiredLength = 9;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedAccount = true;
        }).AddEntityFrameworkStores<AppDbContext>();
    }
}
