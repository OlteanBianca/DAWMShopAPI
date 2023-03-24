namespace ShopAPI.Models
{
    public partial class Inventory
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int ShopId { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual Shop Shop { get; set; } = null!;
    }
}