using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoHub.Startup))]
namespace GoHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
