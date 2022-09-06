using Home_Work.IRepository.Item;
using Home_Work.IRepository.Purchase;
using Home_Work.IRepository.Sales;
using Home_Work.Repository;
using Home_Work.Repository.Purchase;
using Home_Work.Repository.Sales;

namespace Home_Work
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<ISalesService, SalesService>();
        }
    }
}
