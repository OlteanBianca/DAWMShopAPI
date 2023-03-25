using Microsoft.EntityFrameworkCore;
using ShopAPI.Repositories;
using ShopAPI.Services;

namespace ShopAPI.Settings
{
    public static class Dependencies
    {
        #region Private Methods
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IShopService, ShopService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
        }
        #endregion

        #region Public Methods
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(applicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }
        #endregion
    }
}
