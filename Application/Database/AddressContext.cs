using Microsoft.EntityFrameworkCore;

namespace Cadcorp.Database;

public partial class AddressContext : DbContext
{
    public AddressContext()
    {
    }

    public AddressContext(DbContextOptions<AddressContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=.\\Database\\cadcorp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {

            entity.HasKey(e => e.Uid);
            entity.Property(e => e.Uid)
                .HasColumnType("TEXT (36)")
                .HasColumnName("id");
            entity.Property(e => e.Line1)
                .HasColumnType("TEXT (255)")
                .HasColumnName("line1");
            entity.Property(e => e.Line2)
                .HasColumnType("TEXT (255)")
                .HasColumnName("line2");
            entity.Property(e => e.Line3)
                .HasColumnType("TEXT (255)")
                .HasColumnName("line3");
            entity.Property(e => e.PostCode)
                .HasColumnType("TEXT (8)")
                .HasColumnName("postcode");
            entity.Property(e => e.Town)
                .HasColumnType("TEXT (255)")
                .HasColumnName("town");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
