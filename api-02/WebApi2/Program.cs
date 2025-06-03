using ClubWorldCup.Core.Business;
using ClubWorldCup.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/api/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)],
            string.Empty
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");





app.MapGet("/api/player", () =>
{
    return new PlayerBusiness().GetAll();   
})
.WithName("GetPlayers");



app.MapGet("/api/player/{number:int}", (int number) =>
{
    //Validate number

    return new PlayerBusiness().FindByNumber(number);
})
.WithName("GetPlayerByNumber");


app.MapPost("/api/player", ([FromBody] Player player) =>
{
    ////Validate player
    //if (player is null || !player.IsValid())
    //{
    //    return Results.BadRequest("Invalid player data.");
    //}

    var pb = new PlayerBusiness();
    pb.Add(player);

    return pb.GetAll();
})
.WithName("PostPlayer");





app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary, string? City)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
