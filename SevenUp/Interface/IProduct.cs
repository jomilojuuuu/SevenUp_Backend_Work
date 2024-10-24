using SevenUpClassLib.Models;

namespace SevenUp.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetProductsByCategory(int categoryId);

        Task<List<Product>> GetAllProductsAsync();
    }
}
