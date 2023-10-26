using BrasserieManager.Services.BrasserieAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class BiereGrossiste
    {
        [Key]
        public int BiereGrossisteId { get; set; }
        [Required]
        public int GrossisteId { get; set; }
        [Required]
        public int BiereId { get; set; }
        public int Stock { get; set; }
        [ForeignKey("GrossisteId")]
        public Grossiste? Grossiste { get; set; }
        [ForeignKey("BiereId")]
        public Biere? Biere { get; set; }
    }
}
