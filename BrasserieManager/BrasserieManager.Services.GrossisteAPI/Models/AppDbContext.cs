using BrasserieManager.Services.BrasserieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Grossiste> Grossistes { get; set; }
        public DbSet<BiereGrossiste> BiereGrossistes { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Grossistes = Set<Grossiste>();
            BiereGrossistes = Set<BiereGrossiste>();
        }

        public AppDbContext()
        {
            Grossistes = Set<Grossiste>();
            BiereGrossistes = Set<BiereGrossiste>();
        }
    }
}
