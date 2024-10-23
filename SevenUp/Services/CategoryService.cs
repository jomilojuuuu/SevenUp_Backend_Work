using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Seven_up.Data;
using Seven_up.Interface;
using Seven_up.Library.Models;

namespace Seven_up.Services
{
    public class CategoryService(drinkDb drinkDb) : ICategory
    {
        private readonly drinkDb _drinkDb = drinkDb;

        public async Task<Category> AddCategoryAsync(Category model)
        {
            if (model is null)
                return null!;
            await CheckName(model.Name);

            var newDataAdded = _drinkDb.Categories.Add(model).Entity;
            await Commit();
            return model;
        }

        public async Task<Category> EditCategoryAsync(Category model)
        {
            var categories = await _drinkDb.Categories.FindAsync(model.Id);
            if (categories is null)
                return null!;
            categories.Name = model.Name;

            await Commit();
            return model;

        }

        public async Task<List<Category>> GetAllCategoriesAsync() =>
             await _drinkDb.Categories
                .AsNoTracking()
                .ToListAsync();

        public async Task<Category> RemoveCategoryAsync(int id)
        {
            var category = await _drinkDb.Categories.FindAsync(id);
            if (category is null)
                return null!;
            _drinkDb.Categories.Remove(category);
            await Commit();
            return category;
        }

        private async Task CheckName(string name)
        {
            var product = await _drinkDb.Products.FirstOrDefaultAsync(x => x.Name!.ToLower()!.Equals(name.ToLower()));
            return;
        }

        private async Task Commit() => await _drinkDb.SaveChangesAsync();
    }
}
