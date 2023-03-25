using System.ComponentModel.DataAnnotations;

namespace ShopAPI.DTOs
{
    public class InventoryDTO
    {
        [Required]
        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int ShopId { get; set; }
    }
}
