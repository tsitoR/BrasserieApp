using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Net.Sockets;
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
        [Fact]
        public async void BrasserieRepository_CreateBrasserie_Success()
        {
            var mockSet = new Mock<DbSet<Brasserie>>();
            var dbcontext = new Mock<AppDbContext>();
            dbcontext.Setup(m => m.Brasserie).Returns(mockSet.Object);

            var repository = new BrasserieRepository(dbcontext.Object);
            var result = await repository.CreateUpdateBrasserieAsync(new Brasserie
            {
                BrasserieId = 3,
                Nom = "Heineken"
            });
            Assert.True(result.BrasserieId == 3);
        }
        [Fact]
        public async void BrasserieRepository_DeleteBrasserie_Success()
        {
            var _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            using var context = new AppDbContext(_options);
            context.Brasserie.Add(new Brasserie
            {
                BrasserieId = 3,
                Nom = "Heineken"
            });
            context.SaveChanges();

            var repository = new BrasserieRepository(context);
            var result = await repository.DeleteBrasserieAsync(3);

            Assert.True(result);

        }
    }
}
