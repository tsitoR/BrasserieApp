using BrasserieManager.Services.GrossisteAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Repository
{
    public class BiereGrossisteRepository : IBiereGrossisteRepository
    {
        public Task<BiereGrossiste> CreateUpdateBiereGrossiste(BiereGrossiste biereGrossiste)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBiereGrossiste(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BiereGrossiste> GetBiereGrossisteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByBiereAsync(int idBiere)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BiereGrossiste>> GetBiereGrossistesByGrossisteAsync(int idGrossiste)
        {
            throw new NotImplementedException();
        }
    }
}
