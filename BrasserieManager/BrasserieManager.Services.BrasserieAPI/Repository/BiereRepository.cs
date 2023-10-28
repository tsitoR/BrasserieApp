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
        public async Task<Biere> CreateUpdateBiereAsync(Biere biere)
        {
            try
            {
                if (biere.BiereId > 0)
                    _appDbContext.Biere.Update(biere);
                else
                    _appDbContext.Biere.Add(biere);
                await _appDbContext.SaveChangesAsync();
                return biere;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteBiereAsync(int id)
        {
            try
            {
                Biere? biere = await _appDbContext.Biere
                    .FirstOrDefaultAsync(b => b.BiereId == id);
                if (biere == null)
                    return false;
                _appDbContext.Remove(biere);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<Biere> GetBiereByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.Biere
                    .Include(b => b.Brasserie)
                    .FirstOrDefaultAsync(b => b.BiereId == id);
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Biere>> GetBieresAsync()
        {
            try
            {
                return await _appDbContext.Biere
                .Include(b => b.Brasserie)
                .ToListAsync();
            }
            catch { throw;  }
        }
    }
}
