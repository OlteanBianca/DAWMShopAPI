using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class ShopRepository : BaseRepository, IShopRepository
    {
        #region Constructors
        public ShopRepository(AppDBContext shopContext) : base(shopContext) { }
        #endregion

        #region Public Methods
        public async Task<bool> Add(Shop objectToAdd)
        {
            await _shopContext.Shops.AddAsync(objectToAdd);

            await _shopContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var shop = await _shopContext.Shops.FindAsync(id);

            if (shop == null)
            {
                return false;
            }

            _shopContext.Shops.Remove(shop);

            await _shopContext.SaveChangesAsync();

            return true;
        }

        public async Task<Shop?> Get(int? id)
        {
            return await _shopContext.Shops.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Shop>> GetAll()
        {
            return await _shopContext.Shops.ToListAsync();
        }

        public async Task<bool> IfExists(int id)
        {
            return await _shopContext.Shops.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> IfExists(string shopName, int id)
        {
            return await _shopContext.Shops.AnyAsync(p => p.Name == shopName && p.Id != id);
        }

        public async Task<bool> Update(Shop objectToUpdate)
        {
            _shopContext.Shops.Update(objectToUpdate);

            await _shopContext.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
