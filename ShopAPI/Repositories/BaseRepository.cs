namespace ShopAPI.Repositories
{
    public class BaseRepository
    {
        public readonly AppDBContext _shopContext;

        public BaseRepository(AppDBContext shopContext)
        {
            _shopContext = shopContext;
        }
    }
}
