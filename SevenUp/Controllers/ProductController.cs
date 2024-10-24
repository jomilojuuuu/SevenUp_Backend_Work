using Microsoft.AspNetCore.Mvc;
using SevenUp.Interface;
using SevenUpClassLib.Models;

namespace SevenUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct productService) : ControllerBase
    {
        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(int categoryId)
        {
            var products = await productService.GetProductsByCategory(categoryId);
            return Ok(products);
        }
    }
}
