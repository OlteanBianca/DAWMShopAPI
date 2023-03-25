using ShopAPI.DTOs;
using ShopAPI.Models;

namespace ShopAPI.Mappings
{
    public static class InventoryMappingExtension
    {
        #region Entity to DTO
        public static List<InventoryDTO?> ToInventoryDTOs(this List<Inventory> inventories)
        {
            var results = inventories.Select(e => e.ToInventoryDTO()).ToList();

            return results;
        }

        public static InventoryDTO? ToInventoryDTO(this Inventory inventory)
        {
            if (inventory == null) return null;

            var result = new InventoryDTO()
            {
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductId,
                ShopId = inventory.ShopId
            };

            return result;
        }
        #endregion

        #region DTO to Entity
        public static List<Inventory?> ToInventories(this List<InventoryDTO> inventories)
        {
            var results = inventories.Select(e => e.ToInventory()).ToList();

            return results;
        }

        public static Inventory? ToInventory(this InventoryDTO inventory)
        {
            if (inventory == null) return null;

            var result = new Inventory()
            {
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductId,
                ShopId = inventory.ShopId
            };

            return result;
        }
        #endregion
    }
}
