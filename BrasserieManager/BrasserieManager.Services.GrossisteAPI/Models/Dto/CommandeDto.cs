namespace BrasserieManager.Services.GrossisteAPI.Models.Dto
{
    public class CommandeDto
    {
        public int CommandeId { get; set; }
        public double Prix { get; set; }
        public int GrossisteId { get; set; }
        public IEnumerable<BiereCommandeDto> BiereCommandes { get; set; }
    }
}
