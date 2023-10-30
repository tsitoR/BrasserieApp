namespace BrasserieManager.Services.GrossisteAPI.Models.Dto
{
    public class BiereGrossisteDetailsDto
    {
        public int BiereGrossisteId { get; set; }
        public string Grossiste { get; set; }
        public string Biere { get; set; }
        public string Brasserie { get; set; }
        public int Stock { get; set; }
    }
}
