using ShopAPI.DTOs;

namespace ShopAPI.Services
{
    public interface IProductService : IBaseOperationsService<ProductDTO>
    {
        public Task<bool> IfExists(string productName, int id);
    }
}
