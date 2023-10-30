namespace BrasserieManager.Services.BrasserieAPI.Models.Dto
{
    public class BiereDetailsDto
    {
        public int BiereId { get; set; }
        public string? Nom { get; set; }
        public double Alcool { get; set; }
        public double Prix { get; set; }
        public string Brasserie { get; set; }
    }
}
