using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
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
        [Fact]
        public async void BiereRepository_Create_Biere_Success()
        {
            var mockSet = new Mock<DbSet<Biere>>();
            var dbcontext = new Mock<AppDbContext>();
            dbcontext.Setup(m => m.Biere).Returns(mockSet.Object);

            var repository = new BiereRepository(dbcontext.Object);
            var result = await repository.CreateUpdateBiereAsync(new Biere
            {
                BiereId = 2,
                Nom = "IPA",
                Alcool = 5.5,
                Prix = 1,
                BrasserieId = 1
            });
            Assert.True(result.BiereId == 2);
        }
        [Fact]
        public async void BiereRepository_DeleteBiere_Success()
        {
            var _options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            using var context = new AppDbContext(_options);
            context.Biere.Add(new Biere
            {
                BiereId = 5,
                Nom = "Delete me",
                Alcool = 3,
                Prix = 5,
                BrasserieId = 3,
            });
            context.SaveChanges();

            var repository = new BiereRepository(context);
            var result = await repository.DeleteBiereAsync(5);

            Assert.True(result);

        }
    }
}
