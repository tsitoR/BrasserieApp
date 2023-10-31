using BrasserieManager.Services.BrasserieAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrasserieManager.Services.GrossisteAPI.Models.Dto
{
    public class BiereCommandeDto
    {
        public int BiereCommandeId { get; set; }
        public int Quantity { get; set; }
        public int BiereId { get; set; }
        public int CommandeId { get; set; }
    }
}
