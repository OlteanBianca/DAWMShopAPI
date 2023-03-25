using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Services;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        #region Private Fields
        private readonly IProductService _productService;
        #endregion

        #region Constructors
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();

            if (products == null)
            {
                return BadRequest("There are no products in the database.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var product = await _productService.Get(id);

            if (product == null)
            {
                return NotFound("Product doesn't exist!");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDTO product)
        {
            if (product == null)
            {
                return BadRequest("The product can't be null!");
            }

            if (await _productService.IfExists(product.Name, -1))
            {
                return BadRequest("There is already a product with that name.");
            }

            if (await _productService.Add(product))
            {
                return Ok(product);
            }
            return BadRequest("The product was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ProductDTO productDTO)
        {
            if (!await _productService.IfExists(id))
            {
                return BadRequest("There is no product with that id.");
            }
            if (await _productService.IfExists(productDTO.Name, id))
            {
                return BadRequest("There is already a product with that name.");
            }

            if (await _productService.Update(productDTO, id))
            {
                return Ok(productDTO);
            }
            return BadRequest("Invalid product!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productService.GetAll() == null)
            {
                return BadRequest("There are no products in the database.");
            }

            if (await _productService.Get(id) == null)
            {
                return NotFound("The product doesn't exist!");
            }

            if (await _productService.Delete(id))
            {
                return Ok("The product was successfully deleted!");
            }
            return BadRequest("Id invalid!");
        }
        #endregion
    }
}
