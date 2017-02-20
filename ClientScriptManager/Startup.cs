using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientScriptManager.Startup))]
namespace ClientScriptManager
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
