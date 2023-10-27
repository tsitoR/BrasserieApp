using BrasserieManager.Services.GrossisteAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public class GrossisteRepository : IGrossisteRepository
    {
        public Task<Grossiste> CreateUpdateGrossiste(Grossiste grossiste)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGrossiste(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Grossiste> GetGrossisteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grossiste>> GetGrossistesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
