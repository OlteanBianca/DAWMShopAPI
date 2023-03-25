using ShopAPI.DTOs;
using ShopAPI.Mappings;
using ShopAPI.Models;
using ShopAPI.Repositories;

namespace ShopAPI.Services
{
    public class ProductService : IProductService
    {
        #region Private Fields
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructors
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region Public Methods
        public async Task<bool> Add(ProductDTO objectToAdd)
        {
            Product? product = ProductMappingExtension.ToProduct(objectToAdd);
            if (product == null)
            {
                return false;
            }

            await _productRepository.Add(product);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _productRepository.Delete(id);

            return true;
        }

        public async Task<ProductDTO?> Get(int? id)
        {
            Product? product = await _productRepository.Get(id);
            if (product == null) return null;

            return ProductMappingExtension.ToProductDTO(product);
        }

        public async Task<List<ProductDTO?>> GetAll()
        {
            List<Product> products = await _productRepository.GetAll();
            return ProductMappingExtension.ToProductDTOs(products);
        }

        public async Task<bool> IfExists(int id)
        {
            return await _productRepository.IfExists(id);
        }

        public async Task<bool> IfExists(string productName, int id)
        {
            return await _productRepository.IfExists(productName, id);
        }

        public async Task<bool> Update(ProductDTO objectToUpdate, int id)
        {
            Product? product = ProductMappingExtension.ToProduct(objectToUpdate);
            if (product == null)
            {
                return false;
            }
            product.Id = id;

            await _productRepository.Update(product);

            return true;
        }
        #endregion
    }
}
