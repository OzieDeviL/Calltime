using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestProject1.Startup))]
namespace TestProject1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
