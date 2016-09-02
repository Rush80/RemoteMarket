using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RemoteMarket.Startup))]
namespace RemoteMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
