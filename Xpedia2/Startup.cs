using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Xpedia2.Startup))]
namespace Xpedia2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
