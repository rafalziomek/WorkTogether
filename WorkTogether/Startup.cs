using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkTogether.Startup))]
namespace WorkTogether
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
