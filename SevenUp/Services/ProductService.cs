using Microsoft.EntityFrameworkCore;
using SevenUp.Data;
using SevenUp.Interface;
using SevenUpClassLib.Models;

namespace Seven_up.Services
{
    public class ProductService(drinkDb _drinkDb) : IProduct
    {
        private readonly drinkDb _drinkDb = _drinkDb;

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _drinkDb.Products
                .Include(_ => _.Category)
                .ToListAsync();
            return products;
        }



        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            var products = await _drinkDb.Products
                .Where(_ => _.CategoryId == categoryId)
                .ToListAsync();
            return products;
        }


        private async Task Commit() => await _drinkDb.SaveChangesAsync();

        private async Task<Product> CheckName(string name)
        {
            var product = await _drinkDb.Products.FirstOrDefaultAsync(x => x.Name!.ToLower()!.Equals(name.ToLower()));
            return product!;
        }
    }
}