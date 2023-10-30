using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BrasserieManager.Services.GrossisteAPI.RepositoryTest
{
    public class BiereGrossisteRepositoryTest
    {
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BrasserieManager;Trusted_Connection=true;MultipleActiveResultSets=true";
        public BiereGrossisteRepositoryTest()
        {

        }
        [Fact]
        public async void BiereGrossisteRepository_GetBiereGrossiste_By_Id_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BiereGrossisteRepository biereGrossisteRepo = new(context);
            var result = await biereGrossisteRepo.GetBiereGrossisteByIdAsync(1);
            Assert.Equal("GeneDrinks", result.Grossiste?.Nom);
            Assert.Equal("Leffe blonde", result.Biere?.Nom);
        }
        [Fact]
        public async void BiereGrossisteRepository_GetBiereGrossiste_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            BiereGrossisteRepository biereGrossisteRepo = new(context);
            var result = await biereGrossisteRepo.GetBiereGrossistesAsync();
            Assert.True(result.Any());
        }
        [Fact]
        public async void BiereGrossisteRepository_CreateBiereGrossiste_Success()
        {
            var mockSet = new Mock<DbSet<BiereGrossiste>>();
            var dbcontext = new Mock<AppDbContext>();
            dbcontext.Setup(m => m.BiereGrossiste).Returns(mockSet.Object);

            var repository = new BiereGrossisteRepository(dbcontext.Object);
            var result = await repository.CreateUpdateBiereGrossisteAsync(new BiereGrossiste
            {
                BiereGrossisteId = 3,
                BiereId = 1,
                GrossisteId = 1,
                Stock = 5
            });
            Assert.True(result.BiereGrossisteId == 3);
        }
        [Fact]
        public async void BiereGrossisteRepository_DeleteBiereGrossiste_Success()
        {
            var _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            using var context = new AppDbContext(_options);
            context.BiereGrossiste.Add(new BiereGrossiste
            {
                BiereGrossisteId = 2,
                BiereId = 1,
                GrossisteId = 1,
                Stock = 4,
            });
            context.SaveChanges();

            var repository = new BiereGrossisteRepository(context);
            var result = await repository.DeleteBiereGrossisteAsync(2);

            Assert.True(result);
        }
    }
}
