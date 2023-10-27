using BrasserieManager.Services.GrossisteAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public interface IGrossisteRepository
    {
        public Task<Grossiste> GetGrossisteByIdAsync(int id);
        public Task<IEnumerable<Grossiste>> GetGrossistesAsync();
        public Task<bool> DeleteGrossiste(int id);
        public Task<Grossiste> CreateUpdateGrossiste(Grossiste grossiste);
    }
}
