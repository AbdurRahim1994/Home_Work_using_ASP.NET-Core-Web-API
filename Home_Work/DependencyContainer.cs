using Home_Work.IRepository.Item;
using Home_Work.Repository;

namespace Home_Work
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
        }
    }
}
