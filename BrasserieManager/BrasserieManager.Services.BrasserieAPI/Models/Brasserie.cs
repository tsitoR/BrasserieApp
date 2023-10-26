using System.ComponentModel.DataAnnotations;

namespace BrasserieManager.Services.BrasserieAPI.Models
{
    public class Brasserie
    {
        [Key]
        public int BrasserieId { get; set; }
        [Required]
        public string? Nom { get; set; }
    }
}
