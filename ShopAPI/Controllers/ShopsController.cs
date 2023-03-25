using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Services;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopsController : Controller
    {
        #region Private Fields
        private readonly IShopService _shopService;
        #endregion

        #region Constructors
        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shops = await _shopService.GetAll();

            if (shops == null)
            {
                return BadRequest("There are no shops in the database.");
            }

            return Ok(shops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var shop = await _shopService.Get(id);

            if (shop == null)
            {
                return NotFound("The shop doesn't exist!");
            }

            return Ok(shop);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ShopDTO shop)
        {
            if (shop == null)
            {
                return BadRequest("The shop can't be null!");
            }

            if (await _shopService.IfExists(shop.Name, -1))
            {
                return BadRequest("There is already a shop with that name.");
            }

            if (await _shopService.Add(shop))
            {
                return Ok(shop);
            }
            return BadRequest("The shop was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] ShopDTO shop)
        {
            if (!await _shopService.IfExists(id))
            {
                return BadRequest("There is no shop with that id.");
            }
            if (await _shopService.IfExists(shop.Name, id))
            {
                return BadRequest("There is already a shop with that name.");
            }

            if (await _shopService.Update(shop, id))
            {
                return Ok(shop);
            }
            return BadRequest("Invalid shop!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _shopService.GetAll() == null)
            {
                return BadRequest("There are no shops in the database.");
            }

            if (await _shopService.Get(id) == null)
            {
                return NotFound("The shop doesn't exist!");
            }

            if (await _shopService.Delete(id))
            {
                return Ok("The shop was successfully deleted!");
            }
            return BadRequest("Id invalid!");
        }
        #endregion
    }
}
