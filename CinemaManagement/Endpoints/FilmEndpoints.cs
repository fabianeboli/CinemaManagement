using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Endpoints;

public class FilmEndpoints
{
    public static void Map(WebApplication app)
    {
        var films = app.MapGroup("/films").WithTags("Films");
        films.MapGet("/", GetAllFilms);
        films.MapPost("/", CreateFilm);
        films.MapPut("/{id}", UpdateFilm);
        films.MapDelete("/{id}", DeleteFilm);
    }

    static async Task<IResult> GetAllFilms(CinemaDb db)
    {
        return TypedResults.Ok(await db.Films.ToArrayAsync());
    }

    static async Task<IResult> CreateFilm(CinemaDb db, Film film)
    {
        db.Films.Add(film);
        await db.SaveChangesAsync();

        return TypedResults.Created($"/api/films/{film.Id}", film);
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
}