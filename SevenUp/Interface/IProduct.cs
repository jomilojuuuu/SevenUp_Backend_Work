using Seven_up.Library.Models;

namespace Seven_up.Interface
{
    public interface IProduct
    {
        Task<List<Product>> GetProductsByCategory(int categoryId);

        Task<List<Product>> GetAllProductsAsync();
    }
}
