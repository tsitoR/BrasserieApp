using BrasserieManager.Services.BrasserieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Grossiste> Grossiste { get; set; }
        public DbSet<BiereGrossiste> BiereGrossiste { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Grossiste = Set<Grossiste>();
            BiereGrossiste = Set<BiereGrossiste>();
        }

        public AppDbContext()
        {
            Grossiste = Set<Grossiste>();
            BiereGrossiste = Set<BiereGrossiste>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brasserie>().HasData(new Brasserie
            {
                BrasserieId = 1,
                Nom = "Abbaye de Leffe"
            });
            modelBuilder.Entity<Brasserie>().HasData(new Brasserie
            {
                BrasserieId = 2,
                Nom = "Flying dodo"
            });
            modelBuilder.Entity<Biere>().HasData(new Biere
            {
                BiereId = 1,
                Nom = "Leffe blonde",
                Alcool = 6.5,
                Prix = 1.5,
                BrasserieId = 1
            });
            modelBuilder.Entity<Grossiste>().HasData(new Grossiste { 
                GrossisteId = 1, 
                Nom = "GeneDrinks" 
            });
            modelBuilder.Entity<BiereGrossiste>().HasData(new BiereGrossiste
            {
                BiereGrossisteId = 1,
                BiereId = 1,
                GrossisteId = 1,
                Stock = 10
            });
        }
    }
}
