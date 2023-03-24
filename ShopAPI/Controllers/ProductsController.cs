using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models;
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
            return Ok(await _productRepository.GetAll());
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

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("The product can't be null!");
            }

            if (await _productRepository.Add(product))
            {
                return Ok(product);
            }
            return BadRequest("The product was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return NotFound("There is no product with that id.");
            }
            if (!await _productRepository.IfExists(id))
            {
                return BadRequest("Product name already exists!");
            }
            if (await _productRepository.Update(product))
            {
                return Ok(product);
            }
            return BadRequest("Invalid Product!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productRepository.GetAll() == null)
            {
                return BadRequest("There are no products.");
            }

            if (await _productRepository.Get(id) == null)
            {
                return NotFound("Product doesn't exist!");
            }

            if (await _productRepository.Delete(id))
            {
                return Ok();
            }
            return BadRequest("Id invalid!");
        }
    }
}
