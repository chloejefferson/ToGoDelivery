using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToGoDelivery.Startup))]
namespace ToGoDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
