using System.ComponentModel.DataAnnotations;

namespace BrasserieManager.Services.BrasserieAPI.Models.Dto
{
    public class BrasserieDto
    {
        public int BrasserieId { get; set; }
        public string? Nom { get; set; }
    }
}
