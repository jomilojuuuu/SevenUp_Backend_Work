using Microsoft.EntityFrameworkCore;
using SevenUp.Data;
using SevenUp.Interface;
using SevenUpClassLib.Models;

namespace SevenUp.Services
{
    public class AdminProductService(drinkDb drinkDb) : IAdminProduct
    {
        private readonly drinkDb _drinkDb = drinkDb;
        public async Task<Product> AddProductAsync(Product model)
        {
            if (model is null) return null!;
            var product = await _drinkDb.Products.FirstOrDefaultAsync(x => x.Name!.ToLower()!.Equals(model.Name!.ToLower()));
            if (product != null)
            {
                _drinkDb.Products.Add(model);
                await _drinkDb.SaveChangesAsync();
                return product;
            }
            return model;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var products = await _drinkDb.Products.FindAsync(id);
            if (products != null)
            {
                _drinkDb.Products.Remove(products);
                await _drinkDb.SaveChangesAsync();
                return products;
            }
            return null!;
        }

        public async Task<Product> EditProductAsync(Product model)
        {
            var products = await _drinkDb.Products.FindAsync(model.Id);
            if (products == null)
                return null!;
            products.Name = model.Name;
            products.Price = model.Price;
            products.Category = model.Category;

            await _drinkDb.SaveChangesAsync();
            return model;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _drinkDb.Products
                .Include(_ => _.Category)
                .ToListAsync();
            return products;
        }
    }
}
