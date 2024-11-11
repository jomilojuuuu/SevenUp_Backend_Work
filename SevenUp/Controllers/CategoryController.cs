using Microsoft.AspNetCore.Mvc;
using SevenUp.Interface;
using SevenUpClassLib.Models;

namespace SevenUp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategory categoryService) : ControllerBase
    {
        [HttpPost("Add-Cateogry")]
        public async Task<ActionResult<Category>> AddCategory(Category model)
        {
            if (model is null) return BadRequest("Model is empty");
            var category = await categoryService.AddCategoryAsync(model);
            return Ok(category);
        }

        [HttpPut("Edit-Category")]
        public async Task<ActionResult<Category>> EditCategoryAsync(Category model)
        {
            if (model is null) return BadRequest("Model is null");
            var category = await categoryService.EditCategoryAsync(model);
            return Ok(category);

        }

        [HttpGet("All-Categories")]
        public async Task<ActionResult<Category>> GetAllCategoriesAsync()
        {
            var category = await categoryService.GetAllCategoriesAsync();
            if (category is null || !category.Any())
                return NotFound("No Categories found.");
            return Ok(category);
        }

        [HttpDelete("Delete-Category/{id}")]
        public async Task<ActionResult<Category>> RemoveCategoryAsync(int id)
        {
            if (id == 0) return NotFound("category not found");
            var category = await categoryService.RemoveCategoryAsync(id);
            return Ok(category);
        }
    }
}
