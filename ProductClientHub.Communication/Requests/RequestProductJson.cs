namespace ProductClientHub.API.UseCases.Products.Register
{
    public class RequestProductJson
    {
        public string Name { get; set; } = string.Empty;
        public string Brand{ get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}