namespace BrasserieManager.Services.GrossisteAPI.Exceptions
{
    public class BeerNotAvailableException : Exception
    {
        public BeerNotAvailableException(string message) : base(message)
        {
        }
    }
}
