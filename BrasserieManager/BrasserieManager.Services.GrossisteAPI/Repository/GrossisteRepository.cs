using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Models;
using Microsoft.EntityFrameworkCore;
using AppDbContext = BrasserieManager.Services.GrossisteAPI.Models.AppDbContext;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public class GrossisteRepository : IGrossisteRepository
    {
        private readonly AppDbContext _appDbContext;
        public GrossisteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Grossiste> CreateUpdateGrossisteAsync(Grossiste grossiste)
        {
            try
            {
                if (grossiste.GrossisteId > 0)
                    _appDbContext.Grossiste.Update(grossiste);
                else
                    _appDbContext.Grossiste.Add(grossiste);
                await _appDbContext.SaveChangesAsync();
                return grossiste;
            }
            catch { throw; }
        }

        public async Task<bool> DeleteGrossisteAsync(int id)
        {
            try
            {
                Grossiste? grossiste = await GetGrossisteByIdAsync(id);
                if (grossiste == null)
                    return false;
                _appDbContext.Remove(grossiste);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch { throw; }
        }

        public async Task<Grossiste> GetGrossisteByIdAsync(int id)
        {
            try
            {
                return await _appDbContext.Grossiste
                    .FirstOrDefaultAsync(b => b.GrossisteId == id);
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Grossiste>> GetGrossistesAsync()
        {
            try
            {
                return await _appDbContext.Grossiste
                .ToListAsync();
            }
            catch { throw; }
        }
    }
}
