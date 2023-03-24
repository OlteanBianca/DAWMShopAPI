namespace ShopAPI.Models
{
    public partial class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
    }
}