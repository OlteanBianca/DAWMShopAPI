using ShopAPI.DTOs;
using ShopAPI.Models;

namespace ShopAPI.Mappings
{
    public static class ShopMappingExtension
    {
        #region Entity to DTO
        public static List<ShopDTO?> ToShopDTOs(this List<Shop> shops)
        {
            var results = shops.Select(e => e.ToShopDTO()).ToList();

            return results;
        }

        public static ShopDTO? ToShopDTO(this Shop shop)
        {
            if (shop == null) return null;

            var result = new ShopDTO()
            {
                Name = shop.Name,
                Address = shop.Address
            };

            return result;
        }
        #endregion

        #region DTO to Entity
        public static List<Shop?> ToShops(this List<ShopDTO> shops)
        {
            var results = shops.Select(e => e.ToShop()).ToList();

            return results;
        }

        public static Shop? ToShop(this ShopDTO shop)
        {
            if (shop == null) return null;

            var result = new Shop()
            {
                Name = shop.Name,
                Address = shop.Address
            };

            return result;
        }
        #endregion
    }
}
