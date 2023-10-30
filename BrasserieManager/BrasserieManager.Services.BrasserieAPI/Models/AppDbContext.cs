using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.BrasserieAPI.Models
{
    public class AppDbContext : DbContext
    {
        private DbSet<Brasserie> brasserie { get; set; }
        private DbSet<Biere> biere { get; set; }
        public virtual DbSet<Brasserie> Brasserie { get => brasserie; set => brasserie = value; }
        public virtual DbSet<Biere> Biere { get => biere; set => biere = value; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            brasserie = Set<Brasserie>();
            biere = Set<Biere>();
        }

        public AppDbContext()
        {
            brasserie = Set<Brasserie>();
            biere = Set<Biere>();
        }
    }
}
