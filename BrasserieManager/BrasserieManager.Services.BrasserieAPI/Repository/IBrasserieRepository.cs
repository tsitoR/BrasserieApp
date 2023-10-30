using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public interface IBrasserieRepository
    {
        public Task<Brasserie> GetBrasserieByIdAsync(int id);
        public Task<IEnumerable<Brasserie>> GetBrasseriesAsync();
        public Task<bool> DeleteBrasserieAsync(int id);
        public Task<Brasserie> CreateUpdateBrasserieAsync(Brasserie brasserie);
    }
}
