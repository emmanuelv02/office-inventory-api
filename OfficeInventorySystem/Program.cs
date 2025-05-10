using OfficeInventorySystem.Infrastructure;
using FluentValidation.AspNetCore;
using OfficeInventorySystem.Application.DTOs;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddValidatorsFromAssemblyContaining(typeof(EquipmentDtoValidator));
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();

builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
