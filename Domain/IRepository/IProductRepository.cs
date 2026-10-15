using Domain.Models;

namespace Domain.IRepository;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<List<Product>> GetAllProductsAsync();
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(Product product);
}