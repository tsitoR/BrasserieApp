using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public interface IBrasserieRepository
    {
        public Task<Brasserie> GetBrasserieByIdAsync(int id);
        public Task<IEnumerable<Brasserie>> GetBrasseriesAsync();
        public Task<bool> DeleteBrasserie(int id);
        public Task<Brasserie> CreateUpdateBrasserie(Brasserie brasserie);
    }
}
