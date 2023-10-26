using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.BrasserieAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Brasserie> Brasseries { get; set; }
        public DbSet<Biere> Bieres { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Brasseries = Set<Brasserie>();
            Bieres = Set<Biere>();
        }

        public AppDbContext()
        {
            Brasseries = Set<Brasserie>();
            Bieres = Set<Biere>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
