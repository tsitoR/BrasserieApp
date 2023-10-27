using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.BrasserieAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Brasserie> Brasserie { get; set; }
        public DbSet<Biere> Biere { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Brasserie = Set<Brasserie>();
            Biere = Set<Biere>();
        }

        public AppDbContext()
        {
            Brasserie = Set<Brasserie>();
            Biere = Set<Biere>();
        }
    }
}
