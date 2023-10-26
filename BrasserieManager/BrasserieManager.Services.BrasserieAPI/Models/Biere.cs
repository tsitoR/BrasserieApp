using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieManager.Services.BrasserieAPI.Models
{
    public class Biere
    {
        [Key]
        public int BiereId { get; set; }
        [Required]
        public string? Nom { get; set; }
        [Range (0, 100)]
        public double Alcool { get; set; }
        public double Prix { get; set; }
        public int BrasserieId { get; set; }
        [ForeignKey("BrasserieId")]
        public Brasserie? Brasserie { get; set; }

    }
}
