using Microsoft.Owin;
using MyWebsite;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MyWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}