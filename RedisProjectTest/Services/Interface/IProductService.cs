namespace RedisProjectTest.Services.Interface
{
    public interface IProductService
    {
        Task<string> GetProducts();
        Task<string> GetProductById(int id);
        Task<string> SearchProductByText(string text);
    }
}
