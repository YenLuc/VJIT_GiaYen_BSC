using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSC.Startup))]
namespace BSC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
