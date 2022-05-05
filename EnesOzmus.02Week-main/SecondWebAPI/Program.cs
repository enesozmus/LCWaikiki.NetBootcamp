using SecondWebAPI.DBOperations.SeedData;
using SecondWebAPI.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Dependency Extension
/// </summary>
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDependencies(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
/// <summary>
/// Veri tabaný tohumlandý
/// </summary>
DataGenerator.Initialize(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();