using FirstWebAPI.DBOperations;
using FirstWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// In Memory
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("appDB"));
// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// FluentValidation
builder.Services.AddFluentValidationServices();

var app = builder.Build();

// Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();