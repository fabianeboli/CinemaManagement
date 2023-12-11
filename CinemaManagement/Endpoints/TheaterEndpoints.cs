using Cinema.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Endpoints;

public class TheaterEndpoints
{
    public static void Map(WebApplication app)
    {
        var theaters = app.MapGroup("/api/theaters").WithTags("Theaters");

        theaters.MapGet("/", GetAllTheaters);
        theaters.MapPost("/", CreateTheater);
    }

    static async Task<IResult> GetAllTheaters(CinemaDb db)
    {
        return TypedResults.Ok(await db.Theaters
            .Include(t => t.Auditoria)
            .ThenInclude(a => a.Seats)
            .AsSplitQuery()
            .ToListAsync());
    }

    static async Task<IResult> CreateTheater(CinemaDb db, Theater theater)
    {
        db.Theaters.Add(theater);
        await db.SaveChangesAsync();
        return TypedResults.Created($"/theaters/{theater.Id}", theater);
    }
  
}