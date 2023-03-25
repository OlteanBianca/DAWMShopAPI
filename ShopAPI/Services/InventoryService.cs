using ShopAPI.DTOs;
using ShopAPI.Mappings;
using ShopAPI.Models;
using ShopAPI.Repositories;

namespace ShopAPI.Services
{
    public class InventoryService : IInventoryService
    {
        #region Private Fields
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShopRepository _shopRepository;
        #endregion

        #region Constructors
        public InventoryService(IInventoryRepository inventoryRepository, IProductRepository productRepository, IShopRepository shopRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _shopRepository = shopRepository;
        }
        #endregion

        #region Public Methods
        public async Task<bool> Add(InventoryDTO objectToAdd)
        {
            Inventory? inventory = InventoryMappingExtension.ToInventory(objectToAdd);
            if (inventory == null)
            {
                return false;
            }

            Product? product = await _productRepository.Get(inventory.ProductId);
            if (product != null)
            {
                inventory.Product = product;
            }

            Shop? shop = await _shopRepository.Get(inventory.ShopId);
            if (shop != null)
            {
                inventory.Shop = shop;
            }

            await _inventoryRepository.Add(inventory);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _inventoryRepository.Delete(id);

            return true;
        }

        public async Task<InventoryDTO?> Get(int? id)
        {
            Inventory? inventory = await _inventoryRepository.Get(id);
            if (inventory == null) return null;

            return InventoryMappingExtension.ToInventoryDTO(inventory);
        }

        public async Task<List<InventoryDTO?>> GetAll()
        {
            List<Inventory> inventories = await _inventoryRepository.GetAll();
            return InventoryMappingExtension.ToInventoryDTOs(inventories);
        }

        public async Task<bool> IfExists(int id)
        {
            return await _inventoryRepository.IfExists(id);
        }

        public async Task<bool> ProductExists(int id)
        {
            return await _productRepository.IfExists(id);
        }

        public async Task<bool> ShopExists(int id)
        {
            return await _shopRepository.IfExists(id);
        }

        public async Task<bool> Update(InventoryDTO objectToUpdate, int id)
        {
            Inventory? inventory = InventoryMappingExtension.ToInventory(objectToUpdate);
            if (inventory == null)
            {
                return false;
            }
            inventory.Id = id;

            Product? product = await _productRepository.Get(inventory.ProductId);
            if (product != null)
            {
                inventory.Product = product;
            }

            Shop? shop = await _shopRepository.Get(inventory.ShopId);
            if (shop != null)
            {
                inventory.Shop = shop;
            }

            await _inventoryRepository.Update(inventory);

            return true;
        }
        #endregion
    }
}
