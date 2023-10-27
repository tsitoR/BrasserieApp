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
        public async Task<Brasserie> CreateUpdateBrasserieAsync(Brasserie brasserie)
        {
            try
            { 
                if (brasserie.BrasserieId > 0)
                    _appDbContext.Brasserie.Update(brasserie);
                else
                    _appDbContext.Brasserie.Add(brasserie);
                await _appDbContext.SaveChangesAsync();
                return brasserie;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteBrasserieAsync(int id)
        {
            try
            {
                Brasserie? brasserie = await GetBrasserieByIdAsync(id);
                if (brasserie == null)
                    return false;
                _appDbContext.Remove(brasserie);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
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
            try
            {
                return await _appDbContext.Brasserie
                .ToListAsync();
            }
            catch { throw; }
        }
    }
}
