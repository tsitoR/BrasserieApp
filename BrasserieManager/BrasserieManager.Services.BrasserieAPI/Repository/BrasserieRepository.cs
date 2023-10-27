using BrasserieManager.Services.BrasserieAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public class BrasserieRepository : IBrasserieRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrasserieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<Brasserie> CreateUpdateBrasserie(Brasserie brasserie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBrasserie(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Brasserie> GetBrasserieByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.Brasserie
                    .FirstOrDefaultAsync(b => b.BrasserieId == id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Brasserie>> GetBrasseriesAsync()
        {
            return await _appDbContext.Brasserie.ToListAsync();
        }
    }
}
