using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class Commande
    {
        [Key]
        public int CommandeId { get; set; }
        public double Prix { get; set; }
        [Required]
        public int GrossisteId { get; set; }
        [ForeignKey("GrossisteId")]
        public Grossiste? Grossiste { get; set; }
    }
}
