using Microsoft.AspNetCore.Mvc;
using SevenUp.Interface;
using SevenUpClassLib.Models;

namespace SevenUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductController(IAdminProduct adminProduct) : ControllerBase
    {
        [HttpGet("Add-Product")]
        public async Task<ActionResult<Product>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is null");
            var products = await adminProduct.AddProductAsync(model);
            return Ok(products);
        }

        [HttpPut("Edit-Product")]
        public async Task<ActionResult<Product>> EditProduct(Product model)
        {
            if (model is null) return BadRequest("Model is null");
            var products = await adminProduct.EditProductAsync(model);
            return Ok(products);
        }


        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await adminProduct.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<ActionResult<Product>> DeleteProductAsync(int id)
        {
            var response = await adminProduct.DeleteProductAsync(id);
            return Ok(response);
        }
    }
}
