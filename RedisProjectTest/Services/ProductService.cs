using Microsoft.Extensions.Caching.Distributed;
using RedisProjectTest.Services.Interface;

namespace RedisProjectTest.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _cache;
        private const string ProductsCacheKey = "Products";
        private const string ProductCacheKeyPrefix = "Product_";
        private const string SearchProductCacheKeyPrefix = "SearchProduct_";

        public ProductService(HttpClient httpClient, IDistributedCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<string> GetProducts()
        {
            try
            {
                var cacheData = await _cache.GetStringAsync(ProductsCacheKey);
                if (!string.IsNullOrEmpty(cacheData)) return cacheData;
                var response = await _httpClient.GetStringAsync("https://dummyjson.com/products");

                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                await _cache.SetStringAsync(ProductsCacheKey, response, options);
                return response;
            }
            catch
            {
                throw;
            }

        }

        public async Task<string> GetProductById(int id)
        {
            try
            {
                string cacheKey = $"{ProductCacheKeyPrefix}{id}";
                var cacheData = await _cache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cacheData)) return cacheData;

                var response = await _httpClient.GetStringAsync($"https://dummyjson.com/products/{id}");
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                await _cache.SetStringAsync(cacheKey, response, options);
                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> SearchProductByText(string text)
        {
            try
            {
                string cacheKey = $"{SearchProductCacheKeyPrefix}${text}";
                var cacheData = await _cache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cacheData)) return cacheData;

                var response = await _httpClient.GetStringAsync($"https://dummyjson.com/products/search?q={text}");
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };
                await _cache.SetStringAsync(cacheKey, response, options);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
