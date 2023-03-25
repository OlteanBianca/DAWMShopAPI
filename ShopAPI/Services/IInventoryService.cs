using ShopAPI.DTOs;

namespace ShopAPI.Services
{
    public interface IInventoryService : IBaseOperationsService<InventoryDTO>
    {
        public Task<bool> ShopExists(int id);

        public Task<bool> ProductExists(int id);
    }
}
