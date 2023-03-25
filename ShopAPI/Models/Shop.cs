using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Models
{
    public partial class Shop
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(100)]
        public string Address { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
    }
}