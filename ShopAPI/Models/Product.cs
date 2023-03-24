namespace ShopAPI.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public virtual ICollection<Inventory> Inventories { get; } = new List<Inventory>();
    }
}