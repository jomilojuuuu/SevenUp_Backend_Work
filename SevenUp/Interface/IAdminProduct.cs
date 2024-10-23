using Seven_up.Library.Models;

namespace Seven_up.Interface
{
    public interface IAdminProduct
    {
        Task<Product> AddProductAsync(Product model);

        Task<Product> EditProductAsync(Product model);

        Task<List<Product>> GetAllProductsAsync();

        Task<Product> DeleteProductAsync(int id);

    }
}
