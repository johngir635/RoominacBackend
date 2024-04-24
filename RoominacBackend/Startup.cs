using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoominacBackend.Startup))]
namespace RoominacBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
