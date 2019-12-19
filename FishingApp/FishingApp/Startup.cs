using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FishingApp.Startup))]
namespace FishingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
