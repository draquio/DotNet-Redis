using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisProjectTest.Services;
using System.Text.Json;

namespace RedisProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();
                return Ok(JsonDocument.Parse(products));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id = 1)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                return Ok(JsonDocument.Parse(product));
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchProduct([FromQuery] string text)
        {
            try
            {
                var products = await _productService.SearchProductByText(text);
                return Ok(JsonDocument.Parse(products));
            }
            catch
            {
                throw;
            }
        }
    }
}
