using MatchCityNameApi.DataAccess;
using MatchCityNameApi.DataAccess.Models;
using MatchCityNameApi.Domain;
using MatchCityNameApi.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICitiesAccessService, CitiesAccessService>();
builder.Services.AddSingleton<IMongoDbFactory>(
    new MongoDbFactory(builder.Configuration.GetValue<string>("ConnectionStrings:MongoDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cities", async (string startsWith, int? limit,
    ICitiesAccessService cities) =>
{
    var cityFilters = new CityFilterService(cities);
    var filteredCities = cityFilters
    .GetFilteredCitiesAsync(startsWith, limit);

    return await filteredCities;
})
.WithName("GetCitites")
.WithOpenApi();

app.Run();
