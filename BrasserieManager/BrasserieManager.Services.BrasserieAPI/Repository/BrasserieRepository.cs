using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public class BrasserieRepository : IBrasserieRepository
    {
        public Task<Brasserie> CreateUpdateBrasserie(Brasserie brasserie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBrasserie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Brasserie> GetBrasserieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brasserie>> GetBrasseriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
