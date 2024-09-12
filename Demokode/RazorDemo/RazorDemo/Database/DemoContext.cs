using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RazorDemo.WeatherService;

namespace RazorDemo.Database
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        // public DbSet<WeatherForecastDto> WeatherForecasts { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        [StringLength(5, MinimumLength = 4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
