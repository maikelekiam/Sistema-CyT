using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_CyT.Startup))]
namespace Sistema_CyT
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
