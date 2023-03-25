namespace ShopAPI.Repositories
{
    public class BaseRepository
    {
        #region Private Fields
        public readonly AppDBContext _shopContext;
        #endregion

        #region Constructors
        public BaseRepository(AppDBContext shopContext)
        {
            _shopContext = shopContext;
        }
        #endregion
    }
}
