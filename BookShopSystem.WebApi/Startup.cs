using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BookShopSystem.WebApi.Startup))]

namespace BookShopSystem.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
