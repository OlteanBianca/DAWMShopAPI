using System.ComponentModel.DataAnnotations;

namespace ShopAPI.DTOs
{
    public class ShopDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Address { get; set; } = string.Empty;
    }
}
