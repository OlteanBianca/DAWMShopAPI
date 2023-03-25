using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Mappings;
using ShopAPI.Repositories;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            return Ok(ProductMappingExtension.ToProductDTOs(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var product = await _productRepository.Get(id);

            if (product == null)
            {
                return NotFound("Product doesn't exist!");
            }

            return Ok(ProductMappingExtension.ToProductDTO(product));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("The product can't be null!");
            }

            if (await _productRepository.IfExists(product.Name, -1))
            {
                return BadRequest("There is already a product with that name.");
            }

            if (await _productRepository.Add(ProductMappingExtension.ToProduct(product)))
            {
                return Ok(product);
            }
            return BadRequest("The product was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductDTO productDTO)
        {
            if (!await _productRepository.IfExists(id))
            {
                return BadRequest("There is no product with that id.");
            }
            if (await _productRepository.IfExists(productDTO.Name, id))
            {
                return BadRequest("There is already a product with that name.");
            }

            var product = ProductMappingExtension.ToProduct(productDTO);
            product.Id = id;

            if (await _productRepository.Update(product))
            {
                return Ok(productDTO);
            }
            return BadRequest("Invalid product!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productRepository.GetAll() == null)
            {
                return BadRequest("There are no products in the database.");
            }

            if (await _productRepository.Get(id) == null)
            {
                return NotFound("Product doesn't exist!");
            }

            if (await _productRepository.Delete(id))
            {
                return Ok("Product was successfully deleted!");
            }
            return BadRequest("Id invalid!");
        }
    }
}
