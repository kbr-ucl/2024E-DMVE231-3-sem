using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
using OnionDemo.Application.Command;
using OnionDemo.Application.Query;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Infrastructure;
using OnionDemo.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

// Database
// https://github.com/dotnet/SqlClient/issues/2239
// https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
// Add-Migration InitialMigration -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
// Update-Database -Context BookMyHomeContext -Project OnionDemo.DatabaseMigration
builder.Services.AddDbContext<BookMyHomeContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString
            ("BookMyHomeDbConnection"),
        x =>
            x.MigrationsAssembly("OnionDemo.DatabaseMigration")));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
