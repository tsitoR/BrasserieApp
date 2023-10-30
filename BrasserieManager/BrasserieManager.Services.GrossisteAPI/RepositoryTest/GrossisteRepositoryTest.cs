
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace BrasserieManager.Services.GrossisteAPI.RepositoryTest
{
    public class GrossisteRepositoryTest
    {
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=BrasserieManager;Trusted_Connection=true;MultipleActiveResultSets=true";
        public GrossisteRepositoryTest()
        {

        }
        [Fact]
        public async void GrossisteRepository_GetGrossiste_By_Id_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            GrossisteRepository grossisteRepo = new(context);
            var result = await grossisteRepo.GetGrossisteByIdAsync(1);
            Assert.Equal("GeneDrinks", result.Nom);
        }
        [Fact]
        public async void GrossisteRepository_GetGrossistes_Success()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(ConnectionString)
                    .UseInternalServiceProvider(serviceProvider);
            var context = new AppDbContext(builder.Options);
            GrossisteRepository grossisteRepo = new(context);
            var result = await grossisteRepo.GetGrossistesAsync();
            Assert.True(result.Any());
        }
        [Fact]
        public async void GrossisteRepository_CreateGrossiste_Success()
        {
            var mockSet = new Mock<DbSet<Grossiste>>();
            var dbcontext = new Mock<AppDbContext>();
            dbcontext.Setup(m => m.Grossiste).Returns(mockSet.Object);

            var repository = new GrossisteRepository(dbcontext.Object);
            var result = await repository.CreateUpdateGrossisteAsync(new Grossiste
            {
                GrossisteId = 0,
                Nom = "Heineken"
            });
            Assert.True(result.GrossisteId == 0);
        }
        [Fact]
        public async void GrossisteRepository_DeleteGrossiste_Success()
        {
            var _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            using var context = new AppDbContext(_options);
            context.Grossiste.Add(new Grossiste
            {
                GrossisteId = 3,
                Nom = "Unilever"
            });
            context.SaveChanges();

            var repository = new GrossisteRepository(context);
            var result = await repository.DeleteGrossisteAsync(3);

            Assert.True(result);
        }
    }
}
