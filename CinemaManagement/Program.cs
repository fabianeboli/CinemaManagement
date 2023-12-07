using Cinema.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CinemaDb>(opt => opt.UseInMemoryDatabase("Cinema"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var cinemaDb = app.Services.CreateScope().ServiceProvider.GetRequiredService<CinemaDb>();
cinemaDb.Database.EnsureCreated();

var dbTheaters = new[]
{
    new Theater("Cinema 1", new List<Auditorium>()),
    new Theater("Cinema 2", new List<Auditorium>())
};

var film = new[]
{
    new Film("Film 1", "Description 1", "Comedy", 100),
    new Film("Film 2", "Description 2", "Drama", 115)
};

var auditoriums = new[]
{
    new Auditorium("Auditorium 1", dbTheaters[0], new List<Seat>()),
    new Auditorium("Auditorium 2", dbTheaters[1], new List<Seat>())
};

var showtimes = new[]
{
    new Showtime(film[0], DateTime.Now, auditoriums[0]),
    new Showtime(film[1], DateTime.Now, auditoriums[1])
};

var seats = new[]
{
    new Seat(1, "A", "1", auditoriums[0]),
    new Seat(2, "A", "2", auditoriums[0]),
    new Seat(3, "A", "3", auditoriums[0]),
    new Seat(4, "A", "4", auditoriums[0]),
    new Seat(5, "A", "5", auditoriums[0]),
    new Seat(6, "B", "1", auditoriums[0]),
    new Seat(7, "B", "2", auditoriums[0]),
    new Seat(8, "B", "3", auditoriums[0]),
    new Seat(9, "B", "4", auditoriums[0]),
    new Seat(10, "B", "5", auditoriums[0]),
    new Seat(11, "C", "1", auditoriums[0]),
    new Seat(12, "C", "2", auditoriums[0]),
    new Seat(13, "C", "3", auditoriums[0]),
    new Seat(14, "C", "4", auditoriums[0]),
    new Seat(15, "C", "5", auditoriums[0]),
    new Seat(16, "D", "1", auditoriums[0]),
    new Seat(17, "D", "2", auditoriums[0]),
    new Seat(18, "D", "3", auditoriums[0]),
    new Seat(19, "D", "4", auditoriums[0]),
    new Seat(20, "D", "5", auditoriums[0]),
};

var tickets = new[]
{
    new Ticket(showtimes[0], seats[0]),
    new Ticket(showtimes[1], seats[1])
};

var users = new[]
{
    new User("User 1", "User 1", "User 1"),
    new User("User 2", "User 2", "User 2")
};

cinemaDb.Theaters.AddRange(dbTheaters);
cinemaDb.Films.AddRange(film);
cinemaDb.Showtimes.AddRange(showtimes);
cinemaDb.Seats.AddRange(seats);
cinemaDb.Tickets.AddRange(tickets);
cinemaDb.Users.AddRange(users);
cinemaDb.SaveChanges();

var premieres = app.MapGroup("/premieres");

premieres.MapGet("/", GetAllPremieres);
premieres.MapPost("/", CreatePremiere);

static async Task<IResult> GetAllPremieres(CinemaDb db)
{
    return TypedResults.Ok(await db.Showtimes.ToArrayAsync());
}

static async Task<IResult> CreatePremiere(CinemaDb db, Showtime premiere)
{
    db.Showtimes.Add(premiere);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/premieres/{premiere.Id}", premiere);
}

var films = app.MapGroup("/films");

films.MapGet("/", GetAllFilms);
films.MapPost("/", CreateFilm);
films.MapPut("/{id}", UpdateFilm);
films.MapDelete("/{id}", DeleteFilm);

static async Task<IResult> GetAllFilms(CinemaDb db)
{
    return TypedResults.Ok(await db.Films.ToArrayAsync());
}

static async Task<IResult> CreateFilm(CinemaDb db, Film film)
{
    db.Films.Add(film);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/films/{film.Id}", film);
}

static async Task<IResult> UpdateFilm(int id, CinemaDb db, Film film)
{
    var dbFilm = await db.Films.FindAsync(id);
    if (dbFilm is null) return Results.NotFound();
    dbFilm.Description = film.Description;
    dbFilm.Title = film.Title;
    dbFilm.Genre = film.Genre;
    dbFilm.Duration = film.Duration;
    await db.SaveChangesAsync();
    return TypedResults.NoContent();
}

static async Task<IResult> DeleteFilm(CinemaDb db, int id)
{
    var film = await db.Films.FindAsync(id);
    if (film is null) return Results.NotFound();
    db.Films.Remove(film);
    await db.SaveChangesAsync();
    return TypedResults.NoContent();
}

var theaters = app.MapGroup("/theaters");

static async Task<IResult> GetAllTheaters(CinemaDb db)
{
    return TypedResults.Ok(await db.Theaters.ToArrayAsync());
}

static async Task<IResult> CreateTheater(CinemaDb db, Theater theater)
{
    db.Theaters.Add(theater);
    await db.SaveChangesAsync();
    return TypedResults.Created($"/theaters/{theater.Id}", theater);
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}