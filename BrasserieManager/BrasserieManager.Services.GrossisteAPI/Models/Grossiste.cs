using System.ComponentModel.DataAnnotations;

namespace BrasserieManager.Services.GrossisteAPI.Models
{
    public class Grossiste
    {
        [Key]
        public int GrossisteId { get; set; }
        [Required]
        public string? Nom { get; set; }
    }
}
