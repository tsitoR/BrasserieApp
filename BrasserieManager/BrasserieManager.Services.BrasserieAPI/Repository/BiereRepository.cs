using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public class BiereRepository : IBiereRepository
    {
        public Task<Biere> CreateUpdateBiere(Biere biere)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBiere(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Biere> GetBiereByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Biere>> GetBieresAsync()
        {
            throw new NotImplementedException();
        }
    }
}
