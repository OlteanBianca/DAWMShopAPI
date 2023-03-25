using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public interface IShopRepository : IBaseOperations<Shop>
    {
        public Task<bool> IfExists(string shopName, int id);
    }
}
