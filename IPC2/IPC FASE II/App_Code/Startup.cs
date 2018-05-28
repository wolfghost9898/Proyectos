using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPC_FASE_II.Startup))]
namespace IPC_FASE_II
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
