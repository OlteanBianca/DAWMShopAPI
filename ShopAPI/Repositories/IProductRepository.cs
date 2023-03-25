using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public interface IProductRepository : IBaseOperations<Product>
    {
        /// <summary>
        /// Checks if it exists by name for creating unique products.
        /// </summary>
        public Task<bool> IfExists(string productName, int id);
    }
}
