using ShopAPI.DTOs;
using ShopAPI.Models;

namespace ShopAPI.Mappings
{
    public static class ProductMappingExtension
    {
        #region Entity to DTO
        public static List<ProductDTO?> ToProductDTOs(this List<Product> products)
        {
            var results = products.Select(e => e.ToProductDTO()).ToList();

            return results;
        }

        public static ProductDTO? ToProductDTO(this Product product)
        {
            if (product == null) return null;

            var result = new ProductDTO()
            {
                Name = product.Name,
                ExpirationDate = product.ExpirationDate,
                Price = product.Price
            };

            return result;
        }
        #endregion

        #region DTO to Entity
        public static List<Product?> ToProducts(this List<ProductDTO> products)
        {
            var results = products.Select(e => e.ToProduct()).ToList();

            return results;
        }

        public static Product? ToProduct(this ProductDTO product)
        {
            if (product == null) return null;

            var result = new Product()
            {
                Name = product.Name,
                ExpirationDate = product.ExpirationDate,
                Price = product.Price
            };

            return result;
        }
        #endregion
    }
}
