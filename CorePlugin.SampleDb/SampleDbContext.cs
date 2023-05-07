using Microsoft.EntityFrameworkCore;

namespace CorePlugin.SampleDb;

#warning This is just a sample. Replace it with your own.
public class SampleDbContext : DbContext
{
    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options) { }

    public DbSet<SampleDbItem> SampleDbItems { get; set; } = null!;

    // That's how you can seed your database with some data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SampleDbItem>().HasData(
            new SampleDbItem
            {
                Id = 1,
                Description = "Sample database item"
            }
        );
    }
}
