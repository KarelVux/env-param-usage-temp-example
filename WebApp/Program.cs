var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var configuration = builder.Configuration;


// Read environment variables
var envVar1 = configuration["ENV_VAR1"];
var envVar2 = configuration["ENV_VAR2"];

var loggingDefault = configuration["LOGGING:LOGLEVEL:DEFAULT"];
var loggingAspentCore = configuration["LOGGING:LOGLEVEL:MICROSOFT.ASPNETCORE"];

Console.WriteLine($"LOGGING__LOGLEVEL__DEFAULT: {loggingDefault}");
Console.WriteLine($"LOGGING__LOGLEVEL__MICROSOFT__ASPNETCORE: {loggingAspentCore}");
Console.WriteLine($"ENV_VAR1: {envVar1}");
Console.WriteLine($"ENV_VAR2: {envVar2}");

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