using Microsoft.EntityFrameworkCore;

namespace Cadcorp.Database;
public class AddressContext(DbContextOptions<AddressContext> options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
}
