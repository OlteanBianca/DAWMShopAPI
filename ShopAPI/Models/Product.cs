using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
    }
}