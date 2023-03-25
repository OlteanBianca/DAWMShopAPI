using Microsoft.EntityFrameworkCore;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class InventoryRepository : BaseRepository, IInventoryRepository
    {
        #region Constructors
        public InventoryRepository(AppDBContext shopContext) : base(shopContext) { }
        #endregion

        #region Public Methods
        public async Task<bool> Add(Inventory objectToAdd)
        {
            await _shopContext.Inventories.AddAsync(objectToAdd);

            await _shopContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var inventory = await _shopContext.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return false;
            }

            _shopContext.Inventories.Remove(inventory);

            await _shopContext.SaveChangesAsync();

            return true;
        }

        public async Task<Inventory?> Get(int? id)
        {
            return await _shopContext.Inventories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Inventory>> GetAll()
        {
            return await _shopContext.Inventories.ToListAsync();
        }

        public async Task<bool> IfExists(int id)
        {
            return await _shopContext.Inventories.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> Update(Inventory objectToUpdate)
        {
            _shopContext.Inventories.Update(objectToUpdate);

            await _shopContext.SaveChangesAsync();

            return true;
        }
        #endregion
    }
}
