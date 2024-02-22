using Cinema.Endpoints;
using Cinema.Models;
using Microsoft.EntityFrameworkCore;
var x = 5;
var y = x + 5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learwn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CinemaDb>(opt => opt.UseInMemoryDatabase("Cinema"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    // builder.Services.AddReverseProxy();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    // app.MapForwarder("{**catch-all}", "http://localhost:3333");
}

app.UseHttpsRedirection();

var cinemaDb = app.Services.CreateScope().ServiceProvider.GetRequiredService<CinemaDb>();
cinemaDb.Database.EnsureCreated();


var dbTheaters = new[]
{
    new Theater("Cinema 1"),
    new Theater("Cinema 2")
};

var film = new[]
{
    new Film("High and Low", "Description 1", "Comedy", 100,
        "https://m.media-amazon.com/images/M/MV5BOTI4NTNhZDMtMWNkZi00MTRmLWJmZDQtMmJkMGVmZTEzODlhXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_.jpg"),
    new Film("Still life", "Description 2", "Drama", 115,
        "https://m.media-amazon.com/images/M/MV5BOWEzMGIyNWUtZTMzMS00NGY2LTllZWYtMjgwZjRkYWY2NTFkXkEyXkFqcGdeQXVyMTI3ODAyMzE2._V1_.jpg"),
    new Film("Hiroshima", "Description 3", "War", 95,
        "https://m.media-amazon.com/images/M/MV5BNGE1OTFjOTEtM2M2OS00NWRmLWE0NWYtNjFlMzljYmJhNzUwXkEyXkFqcGdeQXVyNjc5NjEzNA@@._V1_.jpg"),
    new Film("Onibaba", "Description 4", "Horror", 183,
        "https://m.media-amazon.com/images/M/MV5BMWRiYmNmNTEtM2FlNC00ODRlLWFiMmQtYmNlNzgxY2MzMzNkL2ltYWdlXkEyXkFqcGdeQXVyNjc1NTYyMjg@._V1_.jpg")
};

var auditoriums = new[]
{
    new Auditorium("Auditorium 1", 1),
    new Auditorium("Auditorium 2", 2)
};

var showtimes = new[]
{
    new Showtime(film[0], DateTime.Now, auditoriums[0]),
    new Showtime(film[0], new DateTime(new DateOnly(2024, 10, 12), new TimeOnly(17, 0, 0), DateTimeKind.Utc), auditoriums[0]),
    new Showtime(film[0], new DateTime(new DateOnly(2024, 10, 12), new TimeOnly(20, 20, 0), DateTimeKind.Utc), auditoriums[0]),
    new Showtime(film[0], new DateTime(new DateOnly(2024, 10, 14), new TimeOnly(17, 0, 0), DateTimeKind.Utc), auditoriums[0]),
    new Showtime(film[0], new DateTime(new DateOnly(2024, 10, 15), new TimeOnly(17, 0, 0), DateTimeKind.Utc), auditoriums[0]),
 
    new Showtime(film[1], DateTime.Now, auditoriums[1])
};

var users = new[]
{
    new User("User 0", "User 1", []),
    new User("User 1", "User 2", [])
};

var seats = new[]
{
    new Seat(1, "A", "1", 1, null),
    new Seat(2, "A", "2", 1, 1),
    new Seat(3, "A", "3", 1, 1),
    new Seat(5, "A", "5", 1, null),
    new Seat(4, "A", "4", 1, null),
    new Seat(6, "B", "1", 1, null),
    new Seat(7, "B", "2", 1, null),
    new Seat(8, "B", "3", 1, null),
    new Seat(9, "B", "4", 1, null),
    new Seat(10, "B", "5", 1, null),
    new Seat(11, "C", "1", 1, null),
    new Seat(12, "C", "2", 1, null),
    new Seat(13, "C", "3", 1, null),
    new Seat(14, "C", "4", 1, null),
    new Seat(15, "C", "5", 1, null),
    new Seat(16, "D", "1", 1, null),
    new Seat(17, "D", "2", 1, null),
    new Seat(18, "D", "3", 1, null),
    new Seat(19, "D", "4", 1, null),
    new Seat(20, "D", "5", 1, null),
};

var tickets = new[]
{
    new Ticket(1, 1),
    new Ticket(1, 2)
};

cinemaDb.Theaters.AddRange(dbTheaters);
cinemaDb.Films.AddRange(film);
cinemaDb.Showtimes.AddRange(showtimes);
cinemaDb.Seats.AddRange(seats);
cinemaDb.Tickets.AddRange(tickets);
cinemaDb.Users.AddRange(users);
cinemaDb.SaveChanges();

app.MapControllers();
app.Run();