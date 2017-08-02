using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Remit.API.Startup))]

namespace Remit.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}