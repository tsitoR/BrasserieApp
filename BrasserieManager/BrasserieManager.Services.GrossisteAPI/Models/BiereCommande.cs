using BrasserieManager.Services.BrasserieAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class BiereCommande
    {
        [Key]
        public int BiereCommandeId { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int BiereId { get; set; }
        [Required]
        public int CommandeId { get; set; }
        [ForeignKey("BiereId")]
        public Biere? Biere { get; set; }
        [ForeignKey("CommandeId")]
        public Commande? Commande { get; set; }
    }
}
