using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calltime.Web.Startup))]
namespace Calltime.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
