using Microsoft.AspNetCore.Mvc;
using SevenUp.Interface;
using SevenUpClassLib.Models; // Ensure this namespace matches your project's structure
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProductController : ControllerBase
    {
        private readonly IAdminProduct _adminProduct; // Use field to store the injected service

        public AdminProductController(IAdminProduct adminProduct)
        {
            _adminProduct = adminProduct; // Initialize the injected service
        }

        [HttpPost("Add-Product")]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product model)
        {
            if (model == null)
                return BadRequest("Model is null");

            var product = await _adminProduct.AddProductAsync(model);
            return CreatedAtAction(nameof(GetAllProductsAsync), new { id = product.Id }, product); // Return 201 Created
        }

        [HttpPut("Edit-Product/{id}")]
        public async Task<ActionResult<Product>> EditProduct(int id, [FromBody] Product model)
        {
            if (model == null || id != model.Id)
                return BadRequest("Model is null or ID mismatch");

            var updatedProduct = await _adminProduct.EditProductAsync(model);
            return Ok(updatedProduct);
        }

        [HttpGet("All-Products")]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            var products = await _adminProduct.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpDelete("Delete-Product/{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var response = await _adminProduct.DeleteProductAsync(id);
            if (response == null)
                return NotFound(); // Return 404 if the product was not found
            return NoContent(); // Return 204 No Content for successful delete
        }
    }
}
