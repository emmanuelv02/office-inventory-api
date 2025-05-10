using OfficeInventorySystem.Infrastructure;
using FluentValidation.AspNetCore;
using OfficeInventorySystem.Application.DTOs;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

const string CORS_CONFIG_NAME = "_myCors";

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(CORS_CONFIG_NAME, p =>
    {
        p.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining(typeof(EquipmentDtoValidator));
builder.Services.AddFluentValidationAutoValidation();


builder.Services.AddControllers();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseCors(CORS_CONFIG_NAME);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
