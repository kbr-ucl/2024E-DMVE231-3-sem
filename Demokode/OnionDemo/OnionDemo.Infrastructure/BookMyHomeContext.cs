using Microsoft.EntityFrameworkCore;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class BookMyHomeContext : DbContext
{
    public BookMyHomeContext(DbContextOptions<BookMyHomeContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// Alternativ til [ComplexType]
        //modelBuilder.Entity<Booking>(b =>
        //    b.ComplexProperty(x => x.ReviewAndRating));
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Host> Hosts { get; set; }
}