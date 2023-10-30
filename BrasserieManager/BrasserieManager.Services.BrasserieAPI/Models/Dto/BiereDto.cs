using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BrasserieManager.Services.BrasserieAPI.Models.Dto
{
    public class BiereDto
    {
        public int BiereId { get; set; }
        public string? Nom { get; set; }
        public double Alcool { get; set; }
        public double Prix { get; set; }
        public int BrasserieId { get; set; }
    }
}
