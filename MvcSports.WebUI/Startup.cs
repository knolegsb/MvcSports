using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSports.WebUI.Startup))]
namespace MvcSports.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
