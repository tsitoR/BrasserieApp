using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BrasserieManager.Services.BrasserieAPI.RepositoryTest
{
    public class BiereRepositoryTest
    {
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BrasserieManager;Trusted_Connection=true;MultipleActiveResultSets=true";
        public BiereRepositoryTest()
        {

        }
        [Fact]
        public async void BiereRepository_GetBiere_By_Id_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BiereRepository biereRepo = new(context);
            var result = await biereRepo.GetBiereByIdAsync(1);
            Assert.Equal("Leffe blonde", result.Nom);
        }
        [Fact]
        public async void BiereRepository_GetBieres_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BiereRepository biereRepo = new(context);
            var result = await biereRepo.GetBieresAsync();
            Assert.True(result.Any());
        }
    }
}
