using BrasserieManager.Services.GrossisteAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public interface IGrossisteRepository
    {
        public Task<Grossiste> GetGrossisteByIdAsync(int id);
        public Task<IEnumerable<Grossiste>> GetGrossistesAsync();
        public Task<bool> DeleteGrossisteAsync(int id);
        public Task<Grossiste> CreateUpdateGrossisteAsync(Grossiste grossiste);
    }
}
