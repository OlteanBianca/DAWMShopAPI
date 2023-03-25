using ShopAPI.DTOs;

namespace ShopAPI.Services
{
    public interface IShopService : IBaseOperationsService<ShopDTO>
    {
        public Task<bool> IfExists(string productName, int id);
    }
}
