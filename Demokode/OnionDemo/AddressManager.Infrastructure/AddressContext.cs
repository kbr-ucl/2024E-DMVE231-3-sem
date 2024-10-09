using AddressManager.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AddressManager.Infrastructure;

public class AddressContext : DbContext
{
    public AddressContext(DbContextOptions<AddressContext> options)
        : base(options)
    {
    }

    public DbSet<Address?> Addresses { get; set; }
}