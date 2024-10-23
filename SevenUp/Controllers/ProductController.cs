using Microsoft.AspNetCore.Mvc;
using Seven_up.Interface;
using Seven_up.Library.Models;

namespace Seven_up.Controllers
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
