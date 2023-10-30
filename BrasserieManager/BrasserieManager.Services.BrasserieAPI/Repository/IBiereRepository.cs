using BrasserieManager.Services.BrasserieAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace BrasserieManager.Services.BrasserieAPI.Repository
{
    public interface IBiereRepository
    {
        public Task<Biere> GetBiereByIdAsync(int id);
        public Task<IEnumerable<Biere>> GetBieresAsync();
        public Task<bool> DeleteBiereAsync(int id);
        public Task<Biere> CreateUpdateBiereAsync(Biere biere);
        public Task<IEnumerable<Biere>> GetBiereByBrasserieAsync(int idBrasserie);
    }
}
