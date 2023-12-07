namespace Cinema.Models;
using Microsoft.EntityFrameworkCore;

public class CinemaDb : DbContext
{
    public CinemaDb(DbContextOptions<CinemaDb> options) : base(options)
    {
    }

    public DbSet<Film> Films => Set<Film>();
    public DbSet<Theater> Theaters  => Set<Theater>();
    public DbSet<Auditorium> Auditoria => Set<Auditorium>();
    public DbSet<Seat> Seats => Set<Seat>();
    public DbSet<Showtime> Showtimes => Set<Showtime>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<User> Users => Set<User>();
}