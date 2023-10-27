using BrasserieManager.Services.GrossisteAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public interface IBiereGrossisteRepository
    {
        public Task<BiereGrossiste> GetBiereGrossisteByIdAsync(int id);
        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesAsync();
        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByGrossisteAsync(int idGrossiste);
        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByBiereAsync(int idBiere);
        public Task<bool> DeleteBiereGrossisteAsync(int id);
        public Task<BiereGrossiste> CreateUpdateBiereGrossisteAsync(BiereGrossiste biereGrossiste);
    }
}
