using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BrasserieManager.Services.BrasserieAPI.RepositoryTest
{
    public class BrasserieRepositoryTest
    {
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BrasserieManager;Trusted_Connection=true;MultipleActiveResultSets=true";
        public BrasserieRepositoryTest()
        {

        }
        [Fact]
        public async void BrasserieRepository_GetBrasserie_By_Id_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BrasserieRepository brasserieRepo = new(context);
            var result = await brasserieRepo.GetBrasserieByIdAsync(1);
            Assert.Equal("Abbaye de Leffe", result.Nom);
        }
        [Fact]
        public async void BrasserieRepository_GetBrasserie_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BrasserieRepository brasserieRepo = new(context);
            var result = await brasserieRepo.GetBrasseriesAsync();
            Assert.True(result.Any());
        }
    }
}
