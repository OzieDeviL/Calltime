using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(needidentityconfig.Startup))]
namespace needidentityconfig
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
