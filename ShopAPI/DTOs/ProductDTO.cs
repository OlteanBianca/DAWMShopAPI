using System.ComponentModel.DataAnnotations;

namespace ShopAPI.DTOs
{
    public class ProductDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
