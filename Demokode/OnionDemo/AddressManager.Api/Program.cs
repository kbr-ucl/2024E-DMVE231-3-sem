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

app.UseHttpsRedirection();


app.MapGet("/ping", () => { return Results.Ok("Ping reply"); });


app.MapPost("/Address", (CreateAddressRequestDto address) =>
    {
        var response = new CreateAddressResponseDto("1234", AddressValidationStateDto.Valid);
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

public record CreateAddressRequestDto(string StreetName, string Building, string ZipCode);

public record CreateAddressResponseDto(string DawaId, AddressValidationStateDto ValidationState);

public record GetAddressResponseDto(string StreetName, string Building, string ZipCode, string City, bool IsValid, string DawaId);

public enum AddressValidationStateDto
{
    NotValidated,
    Pending,
    Valid,
    Invalid
}