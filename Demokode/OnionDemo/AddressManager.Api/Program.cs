using AddressManager.Application;
using AddressManager.Application.Command;
using AddressManager.Application.Command.CommandDto;
using AddressManager.Domain.Values;
using AddressManager.Infrastructure;

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


app.MapGet("/ping", () => { return Results.Ok("Ping reply"); });


app.MapPost("/Address", (CreateAddressRequestDto addressRequest, IAddressCommand addressCommand) =>
    {
        var address = addressCommand.CreateAddress(new CreateAddressCommandDto(addressRequest.StreetName, addressRequest.Building, addressRequest.ZipCode, addressRequest.City));
        var response = new CreateAddressResponseDto(address.DawaAddress.DawaId.ToString(), MapValidationState(address.DawaAddress.ValidationState));
        return Results.Ok(response);
    })
    .WithOpenApi(config => new(config)
    {
        Summary = "Create a new address if DAWA validation is succefull",
        Description =
            "Create a new address in the system. Before the creation of the address the address is validated with a call to DAWA."
    })
    .Accepts<CreateAddressRequestDto>("application/json");



app.MapGet("/Address", (string dawaId) =>
    {
        var response = new GetAddressResponseDto("StreetName", "Building", "ZipCode", "City", true, dawaId);
        return Results.Ok(response);
    })
    .WithOpenApi(config => new(config)
    {
        Summary = "Create a new address if DAWA validation is succefull",
        Description =
            "Create a new address in the system. Before the creation of the address the address is validated with a call to DAWA."
    })
    .Accepts<CreateAddressRequestDto>("application/json");


app.Run();
    
AddressValidationStateDto MapValidationState(AddressValidationState validationState)
{
    switch (validationState)
    {
        case AddressValidationState.Pending:
            return AddressValidationStateDto.Pending;
        case AddressValidationState.Valid:
            return AddressValidationStateDto.Valid;
        case AddressValidationState.Uncertain:
            return AddressValidationStateDto.Uncertain;
        case AddressValidationState.Invalid:
            return AddressValidationStateDto.Invalid;
        default:
            throw new ArgumentOutOfRangeException(nameof(validationState), validationState, null);
    }
}

public record CreateAddressRequestDto(string StreetName, string Building, string ZipCode, string City);

public record CreateAddressResponseDto(string DawaId, AddressValidationStateDto ValidationState);

public record GetAddressResponseDto(string StreetName, string Building, string ZipCode, string City, bool IsValid, string DawaId);

public enum AddressValidationStateDto
{
    Pending,
    Valid,
    Uncertain,
    Invalid
}