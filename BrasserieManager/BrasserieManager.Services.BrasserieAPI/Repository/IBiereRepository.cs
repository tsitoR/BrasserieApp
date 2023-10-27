using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public interface IBiereRepository
    {
        public Task<Biere> GetBiereByIdAsync(int id);
        public Task<IEnumerable<Biere>> GetBieresAsync();
        public Task<bool> DeleteBiere(int id);
        public Task<Biere> CreateUpdateBiere(Biere biere);
    }
}
