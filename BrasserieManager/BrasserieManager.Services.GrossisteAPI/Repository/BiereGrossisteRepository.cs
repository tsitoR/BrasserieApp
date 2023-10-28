using BrasserieManager.Services.GrossisteAPI.Models;
using Microsoft.EntityFrameworkCore;
using AppDbContext = BrasserieManager.Services.GrossisteAPI.Models.AppDbContext;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public class BiereGrossisteRepository : IBiereGrossisteRepository
    {
        private readonly AppDbContext _appDbContext;
        public BiereGrossisteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<BiereGrossiste> CreateUpdateBiereGrossisteAsync(BiereGrossiste biereGrossiste)
        {
            try
            {
                if (biereGrossiste.BiereGrossisteId > 0)
                    _appDbContext.BiereGrossiste.Update(biereGrossiste);
                else
                    _appDbContext.BiereGrossiste.Add(biereGrossiste);
                await _appDbContext.SaveChangesAsync();
                return biereGrossiste;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteBiereGrossisteAsync(int id)
        {
            try
            {
                BiereGrossiste? biereGrossiste = await _appDbContext.BiereGrossiste
                    .FirstOrDefaultAsync(b => b.BiereGrossisteId == id);
                if (biereGrossiste == null)
                    return false;
                _appDbContext.Remove(biereGrossiste);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<BiereGrossiste> GetBiereGrossisteByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.BiereGrossiste
                    .Include(b => b.Grossiste)
                    .Include(b => b.Biere)
                    .FirstOrDefaultAsync(b => b.BiereGrossisteId == id);
            }
            catch { throw; }
        }

        public async Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesAsync()
        {
            try
            {
                return await _appDbContext.BiereGrossiste
                .Include(b => b.Grossiste)
                .Include(b => b.Biere)
                .ToListAsync();
            }
            catch { throw; }
        }

        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByBiereAsync(int idBiere)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByGrossisteAsync(int idGrossiste)
        {
            throw new NotImplementedException();
        }
    }
}
