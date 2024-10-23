using Seven_up.Library.Models;

namespace Seven_up.Interface
{
    public interface ICategory
    {
        Task<Category> AddCategoryAsync(Category model);

        Task<List<Category>> GetAllCategoriesAsync();

        Task<Category> EditCategoryAsync(Category model);

        Task<Category> RemoveCategoryAsync(int id);
    }
}
