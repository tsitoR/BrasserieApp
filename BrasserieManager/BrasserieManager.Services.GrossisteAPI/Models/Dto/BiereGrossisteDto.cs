using BrasserieManager.Services.BrasserieAPI.Models;

namespace BrasserieManager.Services.GrossisteAPI.Models.Dto
{
    public class BiereGrossisteDto
    {
        public int BiereGrossisteId { get; set; }
        public int GrossisteId { get; set; }
        public int BiereId { get; set; }
        public int Stock { get; set; }
        public Grossiste? Grossiste { get; set; }
        public Biere? Biere { get; set; }
    }
}
