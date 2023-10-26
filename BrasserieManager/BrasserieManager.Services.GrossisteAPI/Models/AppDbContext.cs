using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {

        }
    }
}
