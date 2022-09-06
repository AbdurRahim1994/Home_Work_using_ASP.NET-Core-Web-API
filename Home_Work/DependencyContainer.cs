using Home_Work.IRepository.Item;
using Home_Work.IRepository.Partner;
using Home_Work.IRepository.Purchase;
using Home_Work.IRepository.Report;
using Home_Work.Repository;
using Home_Work.Repository.Partner;
using Home_Work.Repository.Purchase;
using Home_Work.Repository.Report;

namespace Home_Work
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IPurchaseService, PurchaseService>();
            services.AddTransient<IPartnerService, PartnerService>();
        }
    }
}
