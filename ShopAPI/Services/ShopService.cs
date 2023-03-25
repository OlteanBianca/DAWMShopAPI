using ShopAPI.DTOs;
using ShopAPI.Mappings;
using ShopAPI.Models;
using ShopAPI.Repositories;

namespace ShopAPI.Services
{
    public class ShopService : IShopService
    {
        #region Private Fields
        private readonly IShopRepository _shopRepository;
        #endregion

        #region Constructors
        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        #endregion

        #region Public Methods
        public async Task<bool> Add(ShopDTO objectToAdd)
        {
            Shop? shop = ShopMappingExtension.ToShop(objectToAdd);
            if (shop == null)
            {
                return false;
            }
            await _shopRepository.Add(shop);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _shopRepository.Delete(id);

            return true;
        }

        public async Task<ShopDTO?> Get(int? id)
        {
            Shop? shop = await _shopRepository.Get(id);
            if (shop == null) return null;

            return ShopMappingExtension.ToShopDTO(shop);
        }

        public async Task<List<ShopDTO?>> GetAll()
        {
            List<Shop> shops = await _shopRepository.GetAll();
            return ShopMappingExtension.ToShopDTOs(shops);
        }

        public async Task<bool> IfExists(int id)
        {
            return await _shopRepository.IfExists(id);
        }

        public async Task<bool> IfExists(string shopName, int id)
        {
            return await _shopRepository.IfExists(shopName, id);
        }

        public async Task<bool> Update(ShopDTO objectToUpdate, int id)
        {
            Shop? shop = ShopMappingExtension.ToShop(objectToUpdate);
            if (shop == null)
            {
                return false;
            }
            shop.Id = id;

            await _shopRepository.Update(shop);

            return true;
        }
        #endregion
    }
}
