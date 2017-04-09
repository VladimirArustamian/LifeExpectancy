namespace LifeExpectancyAnalyzer.Database
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LifeExpectancyContext : DbContext
    {
        public LifeExpectancyContext(DbContextOptions<LifeExpectancyContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Country");
        }
    }
}
