using BrasserieManager.Services.BrasserieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public class BiereRepository : IBiereRepository
    {
        private readonly AppDbContext _appDbContext;
        public BiereRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<Biere> CreateUpdateBiere(Biere biere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBiere(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Biere> GetBiereByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.Biere
                    .FirstOrDefaultAsync(b => b.BrasserieId == id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Biere>> GetBieresAsync()
        {
            return await _appDbContext.Biere
                .Include(b => b.Brasserie)
                .ToListAsync();
        }
    }
}
