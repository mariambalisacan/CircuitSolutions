using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CircuitSolutions.Startup))]
namespace CircuitSolutions
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
