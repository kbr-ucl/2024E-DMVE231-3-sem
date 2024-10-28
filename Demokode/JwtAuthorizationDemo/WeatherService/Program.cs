var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



MapWeather(app);
MapSummaries(app);

app.Run();


void MapWeather(WebApplication webApplication)
{
    webApplication.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        SummariesRepo.Summaries[Random.Shared.Next(SummariesRepo.Summaries.Length)]
                    ))
                .ToArray();
            return forecast;
        })
        .WithName("WeatherForecast")
        .WithOpenApi();
}

void MapSummaries(WebApplication webApplication)
{
    webApplication.MapPost("/summaries", (string[] summaries) =>
        {
            SummariesRepo.Summaries = summaries;
        })
        .WithName("Summaries")
        .WithOpenApi();
}



internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal class SummariesRepo
{
    public static  string[] Summaries  = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
}