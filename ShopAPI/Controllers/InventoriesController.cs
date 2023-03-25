using Microsoft.AspNetCore.Mvc;
using ShopAPI.DTOs;
using ShopAPI.Services;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoriesController : Controller
    {
        #region Private Fields
        private readonly IInventoryService _inventoryService;
        #endregion

        #region Constructors
        public InventoriesController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _inventoryService.GetAll();

            if (inventories == null)
            {
                return BadRequest("There are no inventories in the database.");
            }

            return Ok(inventories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest("The id can't be null!");
            }

            var inventory = await _inventoryService.Get(id);

            if (inventory == null)
            {
                return NotFound("Inventory doesn't exist!");
            }

            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] InventoryDTO inventory)
        {
            if (inventory == null)
            {
                return BadRequest("The inventory can't be null!");
            }

            if (!await _inventoryService.ProductExists(inventory.ProductId))
            {
                return BadRequest("The product doesn't exist!");
            }

            if (!await _inventoryService.ShopExists(inventory.ShopId))
            {
                return BadRequest("The shop doesn't exist!");
            }

            if (await _inventoryService.Add(inventory))
            {
                return Ok(inventory);
            }

            return BadRequest("The inventory was invalid!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] InventoryDTO inventory)
        {
            if (!await _inventoryService.IfExists(id))
            {
                return BadRequest("There is no inventory with that id.");
            }

            if (!await _inventoryService.ProductExists(inventory.ProductId))
            {
                return BadRequest("The product doesn't exist!");
            }

            if (!await _inventoryService.ShopExists(inventory.ShopId))
            {
                return BadRequest("The shop doesn't exist!");

            }
            if (await _inventoryService.Update(inventory, id))
            {
                return Ok(inventory);
            }
            return BadRequest("Invalid inventory!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _inventoryService.GetAll() == null)
            {
                return BadRequest("There are no inventories in the database.");
            }

            if (await _inventoryService.Get(id) == null)
            {
                return NotFound("Inventory doesn't exist!");
            }

            if (await _inventoryService.Delete(id))
            {
                return Ok("Inventory was successfully deleted!");
            }
            return BadRequest("Id invalid!");
        }
        #endregion
    }
}
