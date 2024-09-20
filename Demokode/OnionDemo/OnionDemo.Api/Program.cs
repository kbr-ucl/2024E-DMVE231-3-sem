using Microsoft.AspNetCore.Mvc;
using OnionDemo.Application;
using OnionDemo.Application.Command;
using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.Query;
using OnionDemo.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application and Infrastructure services
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio
app.MapGet("/hello", () => "Hello World");

app.MapGet("/accommodation/{id}/booking", (int id, IBookingQuery query) => query.GetBookings(id));
app.MapGet("/accommodation/{accommodationId}/booking/{bookingId}", (int accommodationId, int bookingId, IBookingQuery query) => query.GetBooking(accommodationId, bookingId));
app.MapPost("/accommodation/booking", ( CreateBookingDto booking, IAccommodationCommand command) => command.CreateBooking(booking));
app.MapPut("/accommodation/booking", (UpdateBookingDto booking, IAccommodationCommand command) => command.UpdateBooking(booking));
app.MapPost("/accommodation",
    (CreateAccommodationDto accommodation, IAccommodationCommand command) => command.Create(accommodation));

app.MapGet("/host/{id}/accommodation", (int id, IHostQuery query) => query.GetAccommodations(id));

app.Run();
