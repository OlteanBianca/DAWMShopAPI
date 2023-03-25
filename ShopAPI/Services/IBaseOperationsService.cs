namespace ShopAPI.Services
{
    public interface IBaseOperationsService<T>
    {
        public Task<bool> Add(T objectToAdd);

        public Task<T?> Get(int? id);

        public Task<List<T?>> GetAll();

        public Task<bool> Delete(int? id);

        public Task<bool> Update(T objectToUpdate, int id);

        public Task<bool> IfExists(int id);
    }
}
