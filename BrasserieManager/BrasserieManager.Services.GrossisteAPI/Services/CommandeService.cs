using BrasserieManager.Services.BrasserieAPI.Models;
using BrasserieManager.Services.BrasserieAPI.Repository;
using BrasserieManager.Services.GrossisteAPI.Exceptions;
using BrasserieManager.Services.GrossisteAPI.Models;
using BrasserieManager.Services.GrossisteAPI.Repository;

namespace BrasserieManager.Services.GrossisteAPI.Services
{
    public class CommandeService
    {

        private readonly IBiereGrossisteRepository _biereGrossisteRepository;
        private readonly IBiereRepository _biereRepository;
        public CommandeService(IBiereGrossisteRepository biereGrossisteRepository, IBiereRepository biereRepository)
        {
            _biereGrossisteRepository = biereGrossisteRepository;
            _biereRepository = biereRepository;
        }
        public async Task<bool> DevisCommande(IEnumerable<BiereCommande> commandeList, int grossisteId, Commande commande, IEnumerable<BiereGrossiste> biereGrossistes)
        {
            bool result = true;
            if (commandeList == null || !commandeList.Any())
                throw new InvalidCommandeException("Commande vide");
            try
            {
                CheckBieresAvailibility(commandeList, biereGrossistes);
                commande.Prix = await TotalPrixCommande(commandeList);
                return result;
            }
            catch { throw; }
        }
        public async Task<double> TotalPrixCommande(IEnumerable<BiereCommande> commandeList)
        {
            double total = 0;
            foreach(BiereCommande biereCommande in commandeList)
            {
                total += await BiereCommandeTotal(biereCommande);
            }
            return total;
        }
        public async Task<double> BiereCommandeTotal(BiereCommande biereCommande)
        {
            Biere biere = await _biereRepository.GetBiereByIdAsync(biereCommande.BiereId);
            return biere.Prix * biereCommande.Quantity;
        }
        public void CheckBieresAvailibility(IEnumerable<BiereCommande> commandeList, IEnumerable<BiereGrossiste> bieresGrossiste)
        {
            foreach (var commande in commandeList)
            {
                if (!bieresGrossiste.Where(bg => bg.BiereId == commande.BiereId).Any())
                {
                    throw (new BeerNotAvailableException("Biere id: " + commande.BiereId + " non disponible"));
                }
                if (!bieresGrossiste.Where(bg => bg.BiereId == commande.BiereId && bg.Stock >= commande.Quantity).Any())
                {
                    throw (new BeerNotAvailableException("Quantité Biere:" + commande.BiereId + " non disponible"));
                }
            }
        }
    }
}
