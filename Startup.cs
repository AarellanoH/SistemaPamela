using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pamela_4._0.Startup))]
namespace Pamela_4._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
